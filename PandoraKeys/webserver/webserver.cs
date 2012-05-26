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
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace PandoraKeys
{

    class WebServer
    {

        private TcpListener myListener;
        private Int32 _port = 5050;
        private IPAddress _localAddr = null;
        private String apppath = AppDomain.CurrentDomain.BaseDirectory;
        private Thread th;
        private Boolean _logEnabled = false;
        private Log _log;
        private Tuner _tuner;

        public Log Logger
        {
            set { _log = value; }

        }
        public Int32 Port
        {
            get { return _port; }
            set { _port = value; }

        }
        public IPAddress localAddr
        {
            get { return _localAddr; }

        }
        public Boolean logEnabled
        {
            get
            {
                return _logEnabled;
            }
            set
            {
                _logEnabled = value;
            }
        }

        public WebServer()
        {

        }
        public WebServer(Int32 port)
        {
            _port = port;

        }
        //The constructor which make the TcpListener start listening on the
        //given port. It also calls a Thread on the method StartListen(). 
        public bool Start(Tuner tuner)
        {
            _tuner = tuner;
            if (tuner == null) return true;

            if (Debugger.IsAttached)
            {
                apppath = "../../webserver";
            }

            IPHostEntry host;

            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    _localAddr = ip;

                }
            }
            if (_localAddr == null) return true;
            StringBuilder log = new StringBuilder();
            try
            {
                //start listing on the given port
                myListener = new TcpListener(_localAddr, _port);
                myListener.Start();
                log.Append("\n IP: " + _localAddr.ToString());
                log.Append("\nWeb Server Running... Press ^C to Stop...");
                //start the thread which calls the method 'StartListen'
                th = new Thread(new ThreadStart(StartListen));
                th.Start();


            }
            catch (Exception e)
            {
                log.Append("\nAn Exception Occurred while Listening :" + e.ToString());
                settext(log.ToString());
                return true;
            }
            settext(log.ToString());
            return false;
        }
        public void shutdown()
        {
            myListener.Stop();
            th.Interrupt();

        }

 
        // Returns The Default File Name
        // Input : WebServerRoot Folder
    
        public string GetTheDefaultFileName(string sLocalDirectory, ref StringBuilder log)
        {
            StreamReader sr;
            String sLine = "";



            try
            {
                //Open the default.dat to find out the list
                // of default file
                sr = new StreamReader(apppath + "\\Default.Dat");

                while ((sLine = sr.ReadLine()) != null)
                {
                    //Look for the default file in the web server root folder
                    if (File.Exists(sLocalDirectory + sLine) == true)
                        break;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                log.Append("\nAn Exception Occurred : " + e.ToString());
            }

            if (File.Exists(sLocalDirectory + sLine) == true)
                return sLine;
            else
                return "";
        }




        // This function takes FileName as Input and returns the mime type..

        public string GetMimeType(string sRequestedFile, ref StringBuilder log)
        {


            StreamReader sr;
            String sLine = "";
            String sMimeType = "";
            String sFileExt = "";
            String sMimeExt = "";

            // Convert to lowercase
            sRequestedFile = sRequestedFile.ToLower();

            int iStartPos = sRequestedFile.IndexOf(".");

            sFileExt = sRequestedFile.Substring(iStartPos);

            try
            {
                //Open the Vdirs.dat to find out the list virtual directories
                sr = new StreamReader(apppath + "\\Mime.Dat");

                while ((sLine = sr.ReadLine()) != null)
                {

                    sLine.Trim();

                    if (sLine.Length > 0)
                    {
                        //find the separator
                        iStartPos = sLine.IndexOf(";");

                        // Convert to lower case
                        sLine = sLine.ToLower();

                        sMimeExt = sLine.Substring(0, iStartPos);
                        sMimeType = sLine.Substring(iStartPos + 1);

                        if (sMimeExt == sFileExt)
                            break;
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                log.Append("\nAn Exception Occurred : " + e.ToString());
            }

            if (sMimeExt == sFileExt)
                return sMimeType;
            else
                return "";
        }

        // Returns the Physical Path
        public string GetLocalPath(string sMyWebServerRoot, string sDirName, ref StringBuilder log)
        {

            StreamReader sr;
            String sLine = "";
            String sVirtualDir = "";
            String sRealDir = "";
            int iStartPos = 0;

            //Remove extra spaces
            sDirName.Trim();

            // Convert to lowercase
            sMyWebServerRoot = sMyWebServerRoot.ToLower();

            // Convert to lowercase
            sDirName = sDirName.ToLower();

            //Remove the slash
            //sDirName = sDirName.Substring(1, sDirName.Length - 2);

            try
            {
                //Open the Vdirs.dat to find out the list virtual directories
                sr = new StreamReader(apppath + "\\VDirs.Dat");

                while ((sLine = sr.ReadLine()) != null)
                {
                    //Remove extra Spaces
                    sLine.Trim();

                    if (sLine.Length > 0)
                    {
                        //find the separator
                        iStartPos = sLine.IndexOf(";");

                        // Convert to lowercase
                        sLine = sLine.ToLower();

                        sVirtualDir = sLine.Substring(0, iStartPos);
                        sRealDir = sLine.Substring(iStartPos + 1);

                        if (sVirtualDir == sDirName)
                        {
                            break;
                        }
                    }
                }
                sr.Close();
            }

            catch (Exception e)
            {
                log.Append("\nAn Exception Occurred : " + e.ToString());
            }

            log.Append("\nVirtual Dir : " + sVirtualDir);
            log.Append("\nDirectory   : " + sDirName);
            log.Append("\nPhysical Dir: " + sRealDir);
            if (sVirtualDir == sDirName)
                return sRealDir;
            else
                return apppath + "/root/" + sDirName;
        }

        /// This function sends the Header Information to the client (Browser)

        public void SendHeader(string sHttpVersion, string sMIMEHeader, int iTotBytes, string sStatusCode, ref Socket mySocket, ref StringBuilder log)
        {

            StringBuilder sBuffer = new StringBuilder();

            // if Mime type is not provided set default to text/html
            if (sMIMEHeader.Length == 0)
            {
                sMIMEHeader = "text/html";  // Default Mime Type is text/html
            }

            log.Append("\nMime type :" + sMIMEHeader);

            sBuffer.Append( sHttpVersion + sStatusCode + "\r\n");
            sBuffer.Append("Server: PandoraControl\r\n");
            sBuffer.Append( "Content-Type: " + sMIMEHeader + "\r\n");

            if (sMIMEHeader.Contains("image") || sMIMEHeader.Contains("javascript") || sMIMEHeader.Contains("css")) sBuffer.Append("Cache-Control: max-age=3600, must-revalidate\r\n");
            else sBuffer.Append("Cache-Control: no-cache\r\n"); // cache only images for now

            sBuffer.Append("Connection: close\r\n"); // added, I need to look in to open sockets. "keep alive"
            sBuffer.Append("Accept-Ranges: bytes\r\n");
            sBuffer.Append("Content-Length: " + iTotBytes + "\r\n\r\n");

            Byte[] bSendData = Encoding.ASCII.GetBytes(sBuffer.ToString());

            SendToBrowser(bSendData, ref mySocket, ref log);
            log.Append("\n\n  Send Header ****************\n" + sBuffer);
            log.Append("\nTotal Bytes : " + iTotBytes.ToString());

        }


        // Overloaded Function, takes string, convert to bytes and calls 
        // overloaded sendToBrowserFunction.

        public void SendToBrowser(String sData, ref Socket mySocket, ref StringBuilder log)
        {
            SendToBrowser(Encoding.ASCII.GetBytes(sData), ref mySocket, ref log);
        }


        // Sends data to the browser (client)

        public void SendToBrowser(Byte[] bSendData, ref Socket mySocket, ref StringBuilder log)
        {
            int numBytes = 0;

            try
            {
                if (mySocket.Connected)
                {
                    if ((numBytes = mySocket.Send(bSendData, bSendData.Length, 0)) == -1)
                        log.Append("\nSocket Error cannot Send Packet");
                    else
                    {
                        log.Append(String.Format("\nNo. of bytes send {0}", numBytes));
                    }
                }
                else
                    log.Append("\nConnection Dropped....");
            }
            catch (Exception e)
            {
                log.Append(String.Format("\nError Occurred : {0} ", e));

            }
        }

        //This method Accepts new connection and
        //process the request

        public void StartListen()
        {

            while (true)
            {
                Socket mySocket = null;
                //Accept a new connection
                try
                {
                    mySocket = myListener.AcceptSocket();
                }
                catch
                {

                    return;
                }

                if (mySocket.Connected)
                {
                    // create a new thread to handle this request
                    Thread th = new Thread(processRequest);
                    th.Start(mySocket);

                }

            }
        }

        private void processRequest(object skt)//Socket socket
        {

            int iStartPos = 0;
            String sRequest;
            String sDirName;
            String sRequestedFile;
            String sErrorMessage;
            String sLocalDir;
            String sMyWebServerRoot = apppath + "/root/";// TODO this needs to be in vdirs or something
            String sPhysicalFilePath = "";
            String sResponse = "";

            Socket socket = (Socket)skt;
            StringBuilder log = new StringBuilder();

            log.Append("\n\n***************************************************\n ");
            log.Append("\nSocket Type " + socket.SocketType);
            log.Append(String.Format("\nClient Connected!!  --   CLient IP {0}\n",
                        socket.RemoteEndPoint));

            int i = 0;
            //make a byte array and receive data from the client 
            Byte[] bReceive = new Byte[1024];
            try
            {
                i = socket.Receive(bReceive);
            }
            catch (SocketException e)
            {
                log.Append("\nRevieve Error i: " + i.ToString() + e.Message);
                socket.Close();
                return;
            }

            if (i == 0) return;
            //Convert Byte to String
            string sBuffer = Encoding.ASCII.GetString(bReceive, 0, i);

            log.Append("\n\n" + sBuffer);

            //At present we will only deal with GET type
            if (sBuffer.Substring(0, 3) != "GET")
            {
                log.Append("\nOnly Get Method is supported..");
                socket.Close();
                return;
            }

            // Look for HTTP request
            iStartPos = sBuffer.IndexOf("HTTP", 1);

            // look for Mobile
            string mobile = "css\\other\\";
            if (sBuffer.Contains("Mobile")) mobile = "css\\mobile\\";
            int l = mobile.Length;

            // Get the HTTP text and version e.g. it will return "HTTP/1.1"
            string sHttpVersion = sBuffer.Substring(iStartPos, 8);


            // Extract the Requested Type and Requested file/directory
            sRequest = sBuffer.Substring(0, iStartPos - 1);


            //Replace backslash with Forward Slash, if Any
            sRequest.Replace("\\", "/");


            //If file name is not supplied add forward slash to indicate 
            //that it is a directory and then we will look for the 
            //default file name..
            if ((sRequest.IndexOf(".") < 1) && (!sRequest.EndsWith("/")))
            {
                sRequest = sRequest + "/";
            }

            //Extract the requested file name
            string[] tokens = sRequest.Split('?');

            if (tokens.Length > 1)
            {
                log.Append("Command: " + tokens[1]);
                bool ret = _tuner.Player.Command(tokens[1], ref log);

            }

            iStartPos = tokens[0].LastIndexOf("/") + 1;
            sRequestedFile = tokens[0].Substring(iStartPos);

            //Extract The directory Name
            sDirName = sRequest.Substring(sRequest.IndexOf("/"), sRequest.LastIndexOf("/") - 3);

            /////////////////////////////////////////////////////////////////////
            // Identify the Physical Directory
            /////////////////////////////////////////////////////////////////////
            if (sDirName == "/")
                sLocalDir = sMyWebServerRoot;
            else
            {
                //Get the Virtual Directory
                sLocalDir = GetLocalPath(sMyWebServerRoot, sDirName, ref log);
            }

            sLocalDir = sLocalDir.Replace("/", "\\");
            sLocalDir = sLocalDir.Replace("\\\\", "\\");
            log.Append("\nDirectory Requested : " + sLocalDir);


            //If the physical directory does not exists then
            // dispaly the error message
            if (sLocalDir.Length == 0)
            {
                sErrorMessage = "<H2>Error!! Requested Directory does not exists</H2><Br>";

                //Format The Message
                SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", ref socket, ref log);

                //Send to the browser
                SendToBrowser(sErrorMessage, ref socket, ref log);

                socket.Close();
                log.Append("\n" + sErrorMessage);
                return;
            }


            /////////////////////////////////////////////////////////////////////
            // Identify the File Name
            /////////////////////////////////////////////////////////////////////

            //If The file name is not supplied then look in the default file list
            if (sRequestedFile.Length == 0)
            {
                // Get the default filename
                sRequestedFile = GetTheDefaultFileName(sLocalDir, ref log);

                if (sRequestedFile == "")
                {
                    sErrorMessage = "<H2>Error!! No Default File Name Specified</H2>";
                    SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", ref socket, ref log);
                    SendToBrowser(sErrorMessage, ref socket, ref log);

                    socket.Close();

                    return;

                }
            }


            /////////////////////////////////////////////////////////////////////
            // Get TheMime Type
            /////////////////////////////////////////////////////////////////////

            String sMimeType = GetMimeType(sRequestedFile, ref log);



            //Build the physical path
            if (sRequestedFile.Contains("css")) sPhysicalFilePath = sLocalDir + mobile + sRequestedFile;
            else sPhysicalFilePath = sLocalDir + sRequestedFile;
            sPhysicalFilePath = sPhysicalFilePath.Replace("/", "\\");
            sPhysicalFilePath = sPhysicalFilePath.Replace("\\\\", "\\");
            
            log.Append("\nFile Requested : " + sPhysicalFilePath);


            if (File.Exists(sPhysicalFilePath) == false)
            {

                sErrorMessage = "<H2>404 Error! File Does Not Exists...</H2>";
                SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", ref socket, ref log);
                SendToBrowser(sErrorMessage, ref socket, ref log);

                log.Append("\n" + sErrorMessage);
            }

            else
            {

                int iTotBytes = 0;

                sResponse = "";

                FileStream fs = new FileStream(sPhysicalFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                // Create a reader that can read bytes from the FileStream.


                BinaryReader reader = new BinaryReader(fs);
                byte[] bytes = new byte[fs.Length];
                int read;
                while ((read = reader.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Read from the file and write the data to the network
                    sResponse = sResponse + Encoding.ASCII.GetString(bytes, 0, read);

                    iTotBytes = iTotBytes + read;

                }
                reader.Close();
                fs.Close();
                if (sMimeType.Contains("xml"))
                {
                    dynamicitems _dynamicitems = null;
                    _tuner.Invoke((MethodInvoker)delegate
                    {
                        _dynamicitems = _tuner.Pitems;
                    });

                    dynamicxml dy = new dynamicxml(_dynamicitems);

                    sResponse = dy.XML;

                    SendHeader(sHttpVersion, sMimeType, sResponse.Length, " 200 OK", ref socket, ref log);

                    SendToBrowser(sResponse, ref socket, ref log);
                }
                else
                {
                    SendHeader(sHttpVersion, sMimeType, iTotBytes, " 200 OK", ref socket, ref log);

                    SendToBrowser(bytes, ref socket, ref log);
                }

            }
            settext(log.ToString());
            socket.Close();
        }
   
        private void settext(string text)
        {
            if (_logEnabled)
            {
                try
                {
                    // the log runs in a different thread
                    _log.Invoke((MethodInvoker)delegate
                    {
                        _log.LogText(text + "\n");
                    });
                }
                catch { }
            }
        }

    }

}