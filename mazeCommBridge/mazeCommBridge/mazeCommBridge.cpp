// mazeCommBridge.cpp : main project file.

#include "windows.h"
#include "stdafx.h"
#include "mazeCOMM.h"
#include <cstring>
#include <string>
#include <iostream>

//sing namespace std;
using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Collections;
#pragma comment(lib, "user32.lib")

int main(array<System::String ^> ^args)
{
	//int s;
	
	//std::cout << "Waiting for Right Click"<< std::endl;
	//while (GetAsyncKeyState(VK_RBUTTON) == 0)
	//{
		//Sleep(1);
	//}

	bool debug=false; //disables mazewalker communication

    const char* address = "127.0.0.1"; // must be 127.0.0.1
	unsigned short portNumber = 3000;

	ArrayList^ multicastGroups = gcnew ArrayList();
    IPAddress^ localAddress = IPAddress::Parse(gcnew String((char *)address));
    IPAddress^ destAddress = nullptr;
   
    bool udpSender = false;
    int bufferSize = 256, sendCount = 5, i;


  array<Byte>^ sendBuffer = gcnew array<Byte>(bufferSize);
  array<Byte>^ receiveBuffer = gcnew array<Byte>(bufferSize);
  int rc;
  UdpClient^ udpSocket = gcnew UdpClient( portNumber );
  IPEndPoint^ senderEndPoint = gcnew IPEndPoint( IPAddress::Any,0 );

  std::cout<<"Listening to "<<address<<":"<<portNumber<< std::endl;

  int mPort=6350;
  bool recVal=false;

  mCOMMstr mComm;
  int ret=-1;
  udpSocket->Client->ReceiveTimeout=500;

   



  std::cout<<"Listening for MazeWalker on "<<mPort<<"...";
	  while(ret<1&&!debug)
	   {
		   ret=mComm.Listen(mPort);
		   std::cout<<".";
	   }
	  std::cout<< std::endl<<"Connected to MazeWalker on "<<mPort<< std::endl;
		mComm.LogVal(-2);


		try//my attempt to clear the buffer, note this only works with a valid timeout, otherwise inifinte loop
				{while(true){receiveBuffer = udpSocket->Receive(senderEndPoint);}}
				catch(SocketException^ e){}
		while(true  )
		{
			char outputChar;

			while(mComm.Connected()<1)
			{
				std::cout<<"Lost Connection... Listening for MazeWalker"<< std::endl;
				ret=mComm.Listen(mPort);
				std::cout<< std::endl<<"Connected to MazeWalker on "<<mPort<< std::endl;

				try//my attempt to clear the buffer
				{while(true){receiveBuffer = udpSocket->Receive(senderEndPoint);}}
				catch(SocketException^ e){}
			}




			try
			{
				recVal=true;
				receiveBuffer = udpSocket->Receive(senderEndPoint);
			}
 			catch(SocketException^ e)
			{
				recVal=false;
			}

            if (receiveBuffer->Length>0&&recVal)
			{
				outputChar = receiveBuffer[receiveBuffer->Length-1];
				std::cout<<outputChar<<" Received"<< std::endl;

				if(!debug)
				{

					if (outputChar == '_')
						mComm.SendCue();
					else if (outputChar == 'A')
						mComm.LookLeft(90);
					else if (outputChar == 'B')
						mComm.MoveForward(5.3);
					else if (outputChar == 'C')
						mComm.LookRight(90);
					else if (outputChar == 'D')
						mComm.StrafeLeft(5.3);
					else if (outputChar == 'G')
						mComm.Jump();
					else if (outputChar == 'F')
						mComm.StrafeRight(5.3);
					else if (outputChar == 'H')
						mComm.MoveBackward(5.3);
					else if (outputChar == 'I')
						mComm.LookLeft(360);
					else if (outputChar == 'E')
						mComm.Jump();
					else if (outputChar == '<')
						mComm.LookLeft(90);
					else if (outputChar == '^')
						mComm.MoveForward(5.3);
					else if (outputChar == '>')
						mComm.LookRight(90);
					else if (outputChar == '«')
						mComm.StrafeLeft(5.3);
					else if (outputChar == '»')
						mComm.StrafeRight(5.3);
					else if (outputChar == 'V')
						mComm.MoveBackward(5.3);
					else if (outputChar == 'M')
						mComm.SendAlert("Look at Matrix", 2000);
					else if (outputChar == 'X')
						mComm.SetScore(50);
					else if (outputChar == 'X')
						mComm.SetPosition(10, 10, 10, 180);
					else if (outputChar == '0')
					{
						mComm.SetMoveSpeed(false, 0);
						mComm.ClearNetJoystick();
					}
					else if (outputChar == '1')
						mComm.SetMoveSpeed(true);
					else if (outputChar == 'L') // Start Turn to Left
					{

						//mComm.SetMoveSpeed(true);
						int ret;
						//double vec[5];
						//ret = mComm.GetPosition(vec);
						//mComm.SetPosition(vec[0], vec[1], 6, 0);
						ret= mComm.SetNetJoystickX(65536 / 2 - 10000);
						//mComm.LookLeft(5);
						//mComm.MoveForward(10000);
					}
					else if (outputChar == 'R') // Start Turn to Right
					{
						//mComm.SetMoveSpeed(true);
						int ret;
						//double vec[5];
						//ret = mComm.GetPosition(vec);
						//mComm.SetPosition(vec[0], vec[1], 6, 0);
						ret = mComm.SetNetJoystickX(65536 / 2 + 10000);
						//mComm.LookRight(5);

						//mComm.MoveForward(10000);
					}
					else if (outputChar == '9') // Set Move Speed (start "car")
					{
						//mComm.SetMoveSpeed(true);
						int ret = mComm.SetNetJoystickY(0);

						//mComm.MoveForward(10000);
					}
					else if (outputChar == '8') // Move back to center
					{
						//mComm.SetMoveSpeed(true);
						int ret;// = mComm.SetNetJoystickX(65536 / 2);
						
						double vec[5];
						 ret = mComm.GetPosition(vec);
						 //mComm.SetPosition(vec[0], vec[1], vec[2], 0);
						 if (vec[2] > 6)
						 {
							 mComm.SetNetJoystickX(65536 / 2-30000);
						 }
						 else if(vec[2] < 6)
						 {
							 mComm.SetNetJoystickX(65536 / 2 + 30000);
						 }

						 do
						 {
							 ret = mComm.GetPosition(vec);
							 std::cout << "zPos Offset: " << vec[2]-6 << std::endl;
						 } while (abs((vec[2] - 6)) > 0.1);
					
						 ret = mComm.SetNetJoystickX(65536 / 2);
							

						

						//mComm.MoveForward(10000);
					}


				else if(outputChar=='Z')
				{
					double vec[5];
					int ret=mComm.GetPosition(vec);
					std::cout<<"mComm: "<<ret<< std::endl;
					std::cout<<"xPos: "<<vec[0]<< std::endl;
					std::cout<<"yPos: "<<vec[1]<< std::endl;
					std::cout<<"zPos: "<<vec[2]<< std::endl;
					std::cout<<"Angle: "<<vec[3]<< std::endl;
					std::cout << "Time: " << vec[4] << std::endl;
				}
				else if(outputChar=='J')
				{
					
					int ret=mComm.SetNetJoystickY(50000);
					Sleep(1000);
					ret=mComm.SetNetJoystickY(65536/2);
					Sleep(1000);
					ret=mComm.SetNetJoystickY(0);
					Sleep(1000);
					ret=mComm.ClearNetJoystick();
				}
				else if(outputChar=='R')
					mComm.SendAlert("Please Record Next Move",4000);
				else
					mComm.LogVal(outputChar);
				}
			}
			
		}
	
		std::cout<<"Disconnecting"<< std::endl;
	  mComm.Disconnect();


    return 0;
}
