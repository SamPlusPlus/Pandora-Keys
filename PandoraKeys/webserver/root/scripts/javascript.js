/*
 * Copyright (C) 2012 David W. Bullington, 
 * and individual contributors.
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 3
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */
 
 function load() {
	getxml(null);
 }

function getxmlparser(){
if      (window.XMLHttpRequest) return new window.XMLHttpRequest(); 
  else if (window.ActiveXObject) { 
     // the many versions of IE's XML fetchers 
     var AXOs = [ 
        'MSXML2.XMLHTTP.6.0', 
        'MSXML2.XMLHTTP.5.0', 
        'MSXML2.XMLHTTP.4.0', 
        'MSXML2.XMLHTTP.3.0', 
        'MSXML2.XMLHTTP', 
        'Microsoft.XMLHTTP', 
        'MSXML.XMLHTTP' 
     ]; 
     for (var i = 0; i < AXOs.length; i++) { 
        try     { return new ActiveXObject(AXOs[i]); } 
        catch(err) { continue; } 
     } 
     return null; 
  } 

}

function getxml(cmd){
	stationlistfocus = false;
	var xmlhttp = getxmlparser();
	if(xmlhttp != null) {
		if(cmd == null)	xmlhttp.open('GET', '/pagedata.xml', false);
		else xmlhttp.open('GET', '/pagedata.xml?' + cmd, false);
		xmlhttp.send();
	}
	else
	{
		alert('no xmlhttp');
	}

	if (xmlhttp.status == 200){
		var st = xmlhttp.responseText;
		if (window.DOMParser)
		{
			parser=new DOMParser();
			xmlDoc=parser.parseFromString(st,"text/xml");
		}
		else // Internet Explorer
		{
			xmlDoc=new ActiveXObject("Microsoft.XMLDOM");
			xmlDoc.async=false;
			xmlDoc.loadXML(st);
		}
 
		try {
			var temp = xmlDoc.getElementsByTagName('TimeRemaining')[0];
			remaining = parseInt(temp.childNodes[0].nodeValue);

			temp = xmlDoc.getElementsByTagName('ElapsedTime')[0];
			elapsedtime = parseInt(temp.childNodes[0].nodeValue);

			temp = xmlDoc.getElementsByTagName('Paused')[0];
			paused = temp.childNodes[0].nodeValue == "true" ? true : false;

			temp = xmlDoc.getElementsByTagName('ThumbUp')[0];
			thumbup = temp.childNodes[0].nodeValue == "true" ? true : false;

			var id = document.getElementById('thumbsup');
			if(thumbup) id.style.display = "";
			else id.style.display = "none";

			id = document.getElementById('albumart');
			temp = xmlDoc.getElementsByTagName('AlbumArtURL')[0];
			id.src = temp.childNodes[0].nodeValue;
			if(id.src.localeCompare("") == 0) id.src = "/images/no_album_art.jpg"

			id = document.getElementById('songtitle');
			var nodes = xmlDoc.getElementsByTagName('Song')[0].childNodes;
			var title = "";
			for(i=0; i<nodes.length; i++)
			{
				if(nodes[i].localName == 'Title'){
					title = nodes[i].textContent;
					break;
				 }
			}
			id.innerHTML = title;
			if(title.indexOf("(") != -1) title = title.substring(0, title.indexOf('('));
			id.href = 'http://en.wikipedia.org/wiki/' + title.replace(/^\s+|\s+$/g, '').replace(/ /g, "_");

			id = document.getElementById('artist');
			temp = xmlDoc.getElementsByTagName('Artist')[0];
			id.innerHTML = temp.childNodes[0].nodeValue;
			id.href = 'http://en.wikipedia.org/wiki/' + temp.childNodes[0].nodeValue.replace(/^\s+|\s+$/g, '').replace(/ /g, "_");


			id = document.getElementById('albumtitle');
			var temp = xmlDoc.getElementsByTagName('AlbumTitle')[0];
			id.innerHTML = temp.childNodes[0].nodeValue;
		
			elements = document.getElementsByTagName('link');
			for(i=0; i<elements.length; i++)
			{
				if(elements[i].href.indexOf("http://www.pandora.com") != -1)
				{
					elements[i].href = "http://www.pandora.com" + xmlDoc.getElementsByTagName('Skin')[0].childNodes[0].nodeValue;
					break;
				}
			}

			id = document.getElementById('shufflecurrent');
			idstationlist = document.getElementById('stationlist');
			id.innerHTML = "";
		
			var stations = xmlDoc.getElementsByTagName('station');
			idstationlist.options.length = 0;
			for(i=0; i<stations.length; i++)
			{
				childNodes = stations[i].childNodes;
				selected = false;
				for(j=0; j<childNodes.length; j++){
					var shuffletitle;
					if(childNodes[j].localName == "Title" )	shuffletitle = childNodes[j].firstChild.nodeValue;
					if(idstationlist.selectedIndex == 0){
						if(childNodes[j].localName == "IsCurrent")
						{
							if(childNodes[j].firstChild.nodeValue == "true")
							{
								id.innerHTML = "Station: " + shuffletitle;
							}
						}
					}
					if(childNodes[j].localName == "IsSelected"){
						if(childNodes[j].firstChild.nodeValue == "true") selected = true;
					}
				}
				idstationlist.options.add(new Option(shuffletitle,shuffletitle,selected));
				if(selected) idstationlist.selectedIndex = i;

			}
		}
		catch(err) {
			
		}



		if(paused) {
			idpause = document.getElementById('divpause');
			idpause.style.display = "";
			id = document.getElementById('pause');
			id.style.display = "none";
			id = document.getElementById('play');
			id.style.display = "";

			delaytime = 0;
			if(ex1running){
				ex1running = false;
				clearInterval(inter);
			}
			songduration = remaining+elapsedtime;
			
			delaytime = songduration*1000/100;
			count = (elapsedtime/songduration) * 100;
			id = document.getElementById('metervalue');
			id.style.width = count+"%";

			return;
		}
		else {
			idpause = document.getElementById('divpause');
			idpause.style.display = "none";
			id = document.getElementById('pause');
			id.style.display = "";
			id = document.getElementById('play');
			id.style.display = "none";

			songduration = remaining+elapsedtime;
			
			delaytime = songduration*1000/100;
			count = (elapsedtime/songduration) * 100;
			if(delaytime == 0){
				if(ex1running){
					ex1running = false;
					clearInterval(inter);
					count = 0;
				}
				if(restarttimer != null){
					clearInterval(restarttimer);
					restarttimer = null;
				}
				restarttimer = setInterval(restart, 2000);
				return;
			}
			else {
				startslider();
			}
		}
		if(cmd != null){
			delaytime = 0;
			if(ex1running){

				ex1running = false;
				clearInterval(inter);
				inter = null;
			}
			if(restarttimer != null){
				clearInterval(restarttimer);
				restarttimer = null;
			}
			restarttimer = setInterval(restart, 2000);
			return;

		}
	}

}


function selstation(id){
	var cmd = 'station=' + encodeURIComponent(id.options[id.selectedIndex].value);
	getxml(cmd);
	stationlistfocus = false;

}
var delaytime = 1000;
var ex1running = false;
var inter = null;
function startslider(){
	if(restarttimer != null){
		clearInterval(restarttimer);
		restarttimer = null;
	}
	if(ex1running){
		clearInterval(inter);
	}
	ex1running = true;
	inter = setInterval(runslider, delaytime);
}
var count = 0;
function runslider(){
	count++;
	var id = document.getElementById('metervalue');
	if(!stationlistfocus) id.style.width = count+"%";		
	if(count >= 100){
		clearInterval(inter);
		ex1running = false;
		restarttimer = setInterval(restart, 5000);
		
	}
}
var restarttimer = null;
function restart(){
	clearInterval(restarttimer);
	restarttimer = null;
	count = 0;
	getxml(null);
}
var stationlistfocus = false;
function onfocusstationlist(id){
	stationlistfocus = true;
}

function onblurstationlist(id){
	stationlistfocus = false;
}