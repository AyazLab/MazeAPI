// mazeCOMM.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <stdlib.h>
#include <stdio.h>
#include <Ws2tcpip.h>
#include <winsock2.h>
bool connected=false;
int BytesSent;

struct tcpMessage
{
	int command= -1000;	//Command code
	int iArg;		//int argument
	double dArgs[4]; //double arguments 

	char* toBytes()
	{
		unsigned char arr[sizeof(int)*2+sizeof(double)*4+4];
		unsigned char cmdArr[sizeof(command)],iArgArr[sizeof(iArg)],dArgArr[sizeof(double)*4];

		memcpy(cmdArr,&command,sizeof(command));
		memcpy(iArgArr,&iArg,sizeof(iArg));
		memcpy(dArgArr,dArgs,sizeof(double)*4);

		for (int x=3;x<sizeof(arr)-1;x++)
		{
			if(x-3<sizeof(int))
				arr[x]=cmdArr[x-3];
			else if(x-3<sizeof(int)*2)
				arr[x]=iArgArr[x-4-3];
			else
				arr[x]=dArgArr[x-8-3];
		}

		arr[0]=7;
		arr[1]=sizeof(arr)-4;
		arr[2]=sizeof(arr)-4;
		unsigned char chksum=0;
		
		for(int x=3;x<sizeof(arr)-1;x++)
		{
			chksum+=arr[x];
		}
		arr[sizeof(arr)-1]=chksum;

		char* ret;
		ret=(char*)malloc(sizeof(arr));
		memcpy(ret,arr,sizeof(arr));
		return ret;
	};

	int storeStringInArr(char* input)
	{
		unsigned char dArgsArr[sizeof(dArgs)];
		sprintf_s((char*)dArgsArr,sizeof(dArgsArr),"%.31s",input);
		memcpy(dArgs,dArgsArr,sizeof(dArgs));
		return 1;
	}

	char* getStringFromArr()
	{
		unsigned char dArgsArr[sizeof(dArgs)];
		char* string;
		memcpy(dArgsArr,dArgs,sizeof(dArgs));
		string=(char*) malloc(sizeof(dArgs));
		strcpy(string,(char*)dArgsArr);
		return string;
	}

	void Process(unsigned char buf[])
	{
		if(Verify(buf))
		{
			command=byteToInt(buf,0+3);
			iArg=byteToInt(buf,sizeof(int)+3);
			dArgs[0]=byteToDouble(buf,sizeof(int)*2+3);
			dArgs[1]=byteToDouble(buf,sizeof(int)*2+sizeof(double)+3);
			dArgs[2]=byteToDouble(buf,sizeof(int)*2+sizeof(double)*2+3);
			dArgs[3]=byteToDouble(buf,sizeof(int)*2+sizeof(double)*3+3);
		}
		else
		{
			command=-1000; //ignored as incorrect
			//message.command=byteToInt(buf,0);
			//message.iArg=byteToInt(buf,sizeof(int));
			//message.dArgs[0]=byteToDouble(buf,sizeof(int)*2);
			//message.dArgs[1]=byteToDouble(buf,sizeof(int)*2+sizeof(double));
			//message.dArgs[2]=byteToDouble(buf,sizeof(int)*2+sizeof(double)*2);
			//message.dArgs[3]=byteToDouble(buf,sizeof(int)*2+sizeof(double)*3);
		}
	}

	int Verify(unsigned char buf[])
	{
		if(buf[0]!=7||buf[1]<5)
			return 0;

		unsigned char chksum=0;

		for (int x=3; x<buf[1]+3;x++)
		{
			chksum+=buf[x];
		}

		return (chksum==buf[buf[1]+3]);
	}

	double byteToDouble(unsigned char buf[], int offset)
	{
		double ret;
		unsigned char dbuf[sizeof(double)];
		dbuf[0]=buf[offset];
		dbuf[1]=buf[offset+1];
		dbuf[2]=buf[offset+2];
		dbuf[3]=buf[offset+3];
		dbuf[4]=buf[offset+4];
		dbuf[5]=buf[offset+5];
		dbuf[6]=buf[offset+6];
		dbuf[7]=buf[offset+7];
		memcpy(&ret,dbuf,sizeof(double));
		return ret;
	}

	int byteToInt(unsigned char buf[],int offset)
	{
		int ret;
		unsigned char dbuf[sizeof(int)];
		dbuf[0]=buf[offset];
		dbuf[1]=buf[offset+1];
		dbuf[2]=buf[offset+2];
		dbuf[3]=buf[offset+3];
		memcpy(&ret,dbuf,sizeof(int));
		return ret;
	}
};

SOCKET serverSocket;
SOCKET clientSocket;
sockaddr_in P1;
sockaddr_in cli_addr;

struct mCOMMstr
{
	//Connection
	__declspec(dllexport)int Connected();
	__declspec(dllexport)int Listen(int port);
	__declspec(dllexport)int ListenFromParams();
	__declspec(dllexport)int ListenFromParams(char* filename);
	__declspec(dllexport)int Disconnect();

	//Misc
	__declspec(dllexport)int SendCue();
	__declspec(dllexport)int LogVal(int iArg);
	__declspec(dllexport)int LogString(char* input);
	__declspec(dllexport)int SendAlert(char* input,int dispTime);
	__declspec(dllexport)int Pause();
	__declspec(dllexport)int NextLevel();
	__declspec(dllexport)int SetPosition(double xPos,double yPos, double zPos,double angle);
	__declspec(dllexport)int GetPosition(double vec[]);
	__declspec(dllexport) int SetPosX(double xPos);
	__declspec(dllexport) int SetPosY(double yPos);
	__declspec(dllexport) int SetPosZ(double zPos);
	__declspec(dllexport) int SetMoveSpeed(bool setToDefault);
	__declspec(dllexport) int SetMoveSpeed(bool setToDefault, double moveSpeed);
	__declspec(dllexport) int EnableGravity(bool enable);
	__declspec(dllexport) int SetRotation(double angle);
	__declspec(dllexport) int GetNextMarker(int *code, int* val);

	__declspec(dllexport) int GetElapsedTime();
	__declspec(dllexport) int GetStatus();
	__declspec(dllexport) int GetStatus(char* statusStr);
	__declspec(dllexport) int GetCurrentMazeName(char* mazeName);

	//Movement
		//Metered Movement
	__declspec(dllexport)int BoundedMovement(bool enable);
	__declspec(dllexport)int MoveForward(double dist);
	__declspec(dllexport)int MoveBackward(double dist);
	__declspec(dllexport)int LookLeft(double angle);
	__declspec(dllexport)int LookRight(double angle);
	__declspec(dllexport)int StrafeLeft(double dist);
	__declspec(dllexport)int StrafeRight(double dist);
		//Joystick Emulation
	__declspec(dllexport)int SetNetJoystickX(int val);
	__declspec(dllexport)int SetNetJoystickY(int val);
	__declspec(dllexport)int SetNetJoystickZ(int val);
	__declspec(dllexport)int SetNetJoystickR(int val);
	__declspec(dllexport)int SetNetJoystick(int netX,int netY,int netZ,int netR);
	__declspec(dllexport)int ClearNetJoystick();
		//Other Movement
	__declspec(dllexport)int Jump();

	//Interaction
	__declspec(dllexport)int SetScore(int iArg);
	__declspec(dllexport)int InstantSetScore(int iArg);
	__declspec(dllexport)int GetScore();
	__declspec(dllexport)int PlayerInteract();

	//Dynamic Object Manipulation

	__declspec(dllexport)int SetDynModelPos(int dynID, double xPos, double yPos, double zPos);
	__declspec(dllexport)int SetDynModelRotationScale(int dynID, double xRot, double yRot, double zRot, double scale);
	__declspec(dllexport)int SetDynModelToNewModel(int dynID, int newModelID);
	__declspec(dllexport)int GetDynModelIDbyLabel(char* label);
	__declspec(dllexport)int GetDynModelStatus(int dID);
	__declspec(dllexport)int GetDynModelStatus(char* label);
	__declspec(dllexport)int GetDynModelPositionAndModel(int dID, double vec[]);
	__declspec(dllexport)int GetDynModelPositionAndModel(char* label, double vec[]);
	__declspec(dllexport)int GetDynModelRotationAndScale(int dID, double vec[]);
	__declspec(dllexport)int GetDynModelRotationAndScale(char* label, double vec[]);

	//Low-Level
	__declspec(dllexport)int Send(tcpMessage m);
	__declspec(dllexport) int Send(int Command);
	__declspec(dllexport) int Send(int Command, int iArg);
	__declspec(dllexport)int Send(int Command, int iArg, double dArgs[]);
	__declspec(dllexport) int mCOMMstr::Send(int Command, int iArg, double dArg1,double dArg2, double dArg3,double dArg4);
	__declspec(dllexport)tcpMessage mCOMMstr::Receive();

};

__declspec(dllexport) int mCOMMstr::ListenFromParams()
{
	return mCOMMstr::ListenFromParams("params.txt");
}
__declspec(dllexport) int mCOMMstr::ListenFromParams(char* filename)
{
	FILE *fp = fopen( filename, "r");
	if(fp==NULL)
	{
		//handle error, can not open file
		return -2;
	}
	int port;
	if( 1 != fscanf(fp,"%d", &port))
	{
		//handle error, incorrect file format
		return -3;
	}

	return mCOMMstr::Listen(port);
}

__declspec(dllexport) int mCOMMstr::Listen(int port)
{
	closesocket(serverSocket);
	closesocket(clientSocket);

	if(port<=0)
		return 0;
	 WSADATA WsaDat;
	 WSAStartup(MAKEWORD(1,1),&WsaDat);

	 
	 P1.sin_family=AF_INET;
	 P1.sin_port=htons(port);
	 //P1.sin_addr.S_un.S_addr=inet_addr(ipAddress);
	 P1.sin_addr.s_addr=INADDR_ANY;

	 serverSocket = socket(AF_INET,SOCK_STREAM,IPPROTO_TCP);
	 
	 bind(serverSocket,(struct sockaddr *)(&P1),sizeof(P1));
	 if(serverSocket==INVALID_SOCKET)
		{
			connected=false;
			return -1;
		}

	listen(serverSocket,1);
	int clilen=sizeof(cli_addr);
	clientSocket = socket(AF_INET,SOCK_STREAM, 0);

	clientSocket=accept(serverSocket,(struct sockaddr*)&cli_addr,&clilen);

	if(clientSocket==INVALID_SOCKET)
		{
			connected=false;
		}
		else
		{
		connected=true;
	}
	 return connected;
}


__declspec(dllexport) int mCOMMstr::Connected()
{
     mCOMMstr::Send(-1000,0);//poll
	 return connected;
}

__declspec(dllexport) int mCOMMstr::Disconnect()
{
	//if(connected)
	//{
		closesocket(clientSocket);
		closesocket(serverSocket);

		WSACleanup();
	//}
	connected=false;
	return 1;
}

__declspec(dllexport) int mCOMMstr::Send(tcpMessage m)
{
	if(connected)
	{
		


		char* mBytes=m.toBytes();

		BytesSent = send(clientSocket, mBytes, 44, 0);

		if (BytesSent < 1 || BytesSent == SOCKET_ERROR)
		{
			printf("send failed: %d\n", WSAGetLastError());
			Disconnect();
		}
		return BytesSent;
	}
	else
		return 0;

}
__declspec(dllexport) int mCOMMstr::Send(int Command, int iArg, double dArgs[])
{
	tcpMessage m;
	m.command=Command;
	m.iArg=iArg;
	memcpy(m.dArgs,dArgs,sizeof(m.dArgs));
	return mCOMMstr::Send(m);
}

__declspec(dllexport) int mCOMMstr::Send(int Command, int iArg, double dArg1,double dArg2, double dArg3,double dArg4)
{
	double dArgs[4];
	dArgs[0]=dArg1;
	dArgs[1]=dArg2;
	dArgs[2]=dArg3;
	dArgs[3]=dArg4;
	return mCOMMstr::Send(Command,iArg,dArgs);
}

__declspec(dllexport) int mCOMMstr::Send(int Command, int iArg)
{
	return mCOMMstr::Send(Command,iArg,0,0,0,0);
}

__declspec(dllexport) int mCOMMstr::Send(int Command)
{
	return mCOMMstr::Send(Command,0,0,0,0,0);
}
__declspec(dllexport) int mCOMMstr::SendCue()
{
	return mCOMMstr::Send(20);
}

__declspec(dllexport) int mCOMMstr::Pause()
{
	return mCOMMstr::Send(10);
}

__declspec(dllexport) int mCOMMstr::SetScore(int iArg)
{
	return mCOMMstr::Send(1,iArg);
}

__declspec(dllexport) int mCOMMstr::InstantSetScore(int iArg)
{
	return mCOMMstr::Send(2,iArg);
}

__declspec(dllexport) int  mCOMMstr::GetCurrentMazeName(char* mazeName)
{
	int ret = mCOMMstr::Send(103, 103, 0, 0, 0, 0);


	tcpMessage m;
	do {
		m = mCOMMstr::Receive();
	} while (m.command != 103 && m.command != -1000);

	if (m.command == 103)
	{
		sprintf(mazeName,"%s", m.getStringFromArr());
		return m.iArg;
	}
	else
	{
		sprintf(mazeName, "Error");
		return -1;
	}

	return 0;

}

__declspec(dllexport) int  mCOMMstr::GetScore()
{
	int ret = mCOMMstr::Send(12, 12, 0, 0, 0, 0);


	tcpMessage m;
	do {
		m = mCOMMstr::Receive();
	} while (m.command != 12 && m.command != -1000);

	if (m.command == 12)
	{

		return m.iArg;
	}
	else
	{
		return -1;
	}

	return 0;

}

__declspec(dllexport) int  mCOMMstr::GetElapsedTime()
{
	int ret = mCOMMstr::Send(102, 102, 0, 0, 0, 0);


	tcpMessage m;
	do {
		m = mCOMMstr::Receive();
	} while (m.command != 102 && m.command != -1000);

	if (m.command == 102)
	{

		return m.iArg;
	}
	else
	{
		return -1;
	}

	return 0;

}

__declspec(dllexport) int  mCOMMstr::GetStatus()
{
	int ret = mCOMMstr::Send(101, 101, 0, 0, 0, 0);


	tcpMessage m;
	do {
		m = mCOMMstr::Receive();
	} while (m.command != 101 && m.command != -1000);

	if (m.command == 101)
	{

		return m.iArg;
	}
	else
	{
		return -1;
	}

	return 0;

}

__declspec(dllexport) int  mCOMMstr::GetStatus(char* statusStr)
{
	int ret = mCOMMstr::Send(101, 101, 0, 0, 0, 0);


	tcpMessage m;
	do {
		m = mCOMMstr::Receive();
	} while (m.command != 101 && m.command != -1000);

	if (m.command == 101)
	{
		switch (m.iArg)
		{
			case 0:
				sprintf(statusStr, "Loading");
				break;
			case 1:
				sprintf(statusStr, "Waiting for API");
				break;
			case 2:
				sprintf(statusStr, "Waiting for Cue");
				break;
			case 3:
				sprintf(statusStr, "MazeList Message");
				break;
			case 4:
				sprintf(statusStr, "Maze Running");
				break;
			case 5:
				sprintf(statusStr, "Maze Paused");
				break;
			default:
				sprintf(statusStr, "Other");
				break;
		}



		return m.iArg;
	}
	else
	{
		return -1;
	}

	return 0;

}


__declspec(dllexport) int mCOMMstr::MoveForward(double dist)
{
	return mCOMMstr::Send(24,dist*100);
}

__declspec(dllexport) int mCOMMstr::MoveBackward(double dist)
{
	return mCOMMstr::Send(25,dist*100);
}

__declspec(dllexport) int mCOMMstr::Jump()
{
	return mCOMMstr::Send(13);
}

__declspec(dllexport) int mCOMMstr::StrafeLeft(double dist)
{
	return mCOMMstr::Send(26,dist*100);
}

__declspec(dllexport) int mCOMMstr::StrafeRight(double dist)
{
	return mCOMMstr::Send(27,dist*100);
}

__declspec(dllexport) int mCOMMstr::LookLeft(double angle)
{
	return mCOMMstr::Send(28,angle*10);
}

__declspec(dllexport) int mCOMMstr::LookRight(double angle)
{
	return mCOMMstr::Send(29,angle*10);
}

__declspec(dllexport) int mCOMMstr::LogVal(int iArg)
{
	return mCOMMstr::Send(-10,iArg);
}

__declspec(dllexport) int mCOMMstr::LogString(char* input)
{
	tcpMessage m;
	m.storeStringInArr(input);
	m.command=-100;
	m.iArg=strlen(input);
	return mCOMMstr::Send(m);
}

__declspec(dllexport) int mCOMMstr::SendAlert(char* input,int dispTime)
{
	tcpMessage m;
	m.storeStringInArr(input);
	m.command=-101;
	m.iArg=dispTime;
	return mCOMMstr::Send(m);
}

__declspec(dllexport) int mCOMMstr::NextLevel()
{
	return mCOMMstr::Send(-500,-500);
}

__declspec(dllexport) int mCOMMstr::SetPosition(double xPos,double yPos, double zPos,double angle)
{
	return mCOMMstr::Send(-90,-90,xPos,yPos,zPos,angle/180.0*(3.14159265/2.0));
}

__declspec(dllexport) int mCOMMstr::SetPosX(double xPos)
{
	return mCOMMstr::Send(-91,-91,xPos,0,0,0);
}

__declspec(dllexport) int mCOMMstr::SetPosY(double yPos)
{
	return mCOMMstr::Send(-92,-92,0,yPos,0,0);
}

__declspec(dllexport) int mCOMMstr::SetPosZ(double zPos)
{
	return mCOMMstr::Send(-93,-93,0,zPos,0,0);
}

__declspec(dllexport) int mCOMMstr::SetRotation(double angle)
{
	return mCOMMstr::Send(-94,-94,0,0,0,angle);
}

__declspec(dllexport) int mCOMMstr::SetMoveSpeed(bool setToDefault)
{
	return mCOMMstr::SetMoveSpeed(setToDefault, 0);
}
__declspec(dllexport) int mCOMMstr::SetMoveSpeed(bool setToDefault, double moveSpeed)
{
	return mCOMMstr::Send(30, setToDefault, moveSpeed, 0, 0, 0);
}

_declspec(dllexport)int mCOMMstr::GetPosition(double vec[])
{
	int ret = mCOMMstr::Send(97,97);
	

	tcpMessage m;
	do{
		m= mCOMMstr::Receive();
	}while(m.command!=97&&m.command!=-1000);

	if(m.command==97)
	{
		
		vec[0]=m.dArgs[0];
		vec[1]=m.dArgs[1];
		vec[2]=m.dArgs[2];
		vec[3]=m.dArgs[3];
		vec[4]=m.iArg; 
		return 1;
	}
	else
	{
		return -1;
	}
}

__declspec(dllexport)int mCOMMstr::GetNextMarker(int* code, int*val)
{
	tcpMessage r;

	if(connected)
	{
		r= mCOMMstr::Receive();

		if(r.command==-1000)
			return -1;
		else
		{
			code[0]=r.command;
			val[0]=r.iArg;
			return 1;
		}
	}
	else return -1;
}

_declspec(dllexport)tcpMessage mCOMMstr::Receive()
{
	tcpMessage message;
	int result=0;
	if(connected)
	{
		char bufstar[sizeof(message)+4];
		unsigned char buf[sizeof(message)+4];
		result=recv(clientSocket,bufstar,sizeof(message)+4,0);


		memcpy(buf,bufstar,44);
		
		message.Process(buf);
	}
	

	if(result==SOCKET_ERROR)
	{
		connected=false;
		message.command = -1000;
		message.iArg = -1000;
	}

	return message;
}

__declspec(dllexport)int mCOMMstr::BoundedMovement(bool enable)
{
	return mCOMMstr::Send(98,enable);
}

__declspec(dllexport)int mCOMMstr::EnableGravity(bool enable)
{
	return mCOMMstr::Send(99, enable);
}


__declspec(dllexport)int mCOMMstr::PlayerInteract()
{
	return mCOMMstr::Send(3);
}

__declspec(dllexport)int mCOMMstr::SetNetJoystickX(int val)
{
	return mCOMMstr::Send(400,1,val,0,0,0);
}

__declspec(dllexport)int mCOMMstr::SetNetJoystickY(int val)
{
	return mCOMMstr::Send(400,2,0,val,0,0);
}

__declspec(dllexport)int mCOMMstr::SetNetJoystickZ(int val)
{
	return mCOMMstr::Send(400,3,0,0,val,0);
}

__declspec(dllexport)int mCOMMstr::SetNetJoystickR(int val)
{
	return mCOMMstr::Send(400,4,0,0,0,val);
}

__declspec(dllexport)int mCOMMstr::SetNetJoystick(int netX, int netY, int netZ, int netR)
{
	return mCOMMstr::Send(400,0,netX,netY,netZ,netR);
}

__declspec(dllexport)int mCOMMstr::ClearNetJoystick()
{
	return mCOMMstr::Send(400,-1,-1,-1,-1,-1);
}



__declspec(dllexport)int mCOMMstr::SetDynModelPos(int dynID, double xPos, double yPos, double zPos)
{
	return mCOMMstr::Send(-297, dynID, xPos, yPos, zPos, 0);
}

__declspec(dllexport)int mCOMMstr::SetDynModelRotationScale(int dynID, double xRot, double yRot, double zRot,double scale)
{
	return mCOMMstr::Send(-298, dynID, xRot, yRot, zRot, scale);
}

__declspec(dllexport)int mCOMMstr::SetDynModelToNewModel(int dynID, int newModelID)
{
	return mCOMMstr::Send(-299, dynID, newModelID,0,0,0);
}

_declspec(dllexport)int mCOMMstr::GetDynModelIDbyLabel(char* label)
{
	tcpMessage m;
	m.storeStringInArr(label);
	m.command = 290;
	m.iArg = -1;
	int ret = mCOMMstr::Send(m);


	do {
		m = mCOMMstr::Receive();
	} while (m.command != 290 && m.command != -1000);

	if (m.command == 290 && m.command != -999)
	{
		int dID = m.iArg;
		return dID;
	}
	else
	{
		return -1;
	}
}

_declspec(dllexport)int mCOMMstr::GetDynModelPositionAndModel(int dID,double vec[])
{
	int ret = mCOMMstr::Send(297, dID);


	tcpMessage m;
	do {
		m = mCOMMstr::Receive();
	} while (m.command != 297 && m.command != -1000);

	if (m.command == 297&&m.command!=-999)
	{

		vec[0] = m.dArgs[0];
		vec[1] = m.dArgs[1];
		vec[2] = m.dArgs[2];
		vec[3] = m.dArgs[3];
		vec[4] = m.iArg;
		return 1;
	}
	else
	{
		return -1;
	}
}

_declspec(dllexport)int mCOMMstr::GetDynModelPositionAndModel(char* label, double vec[])
{
	tcpMessage m;
	m.storeStringInArr(label);
	m.command = 297;
	m.iArg = -1;
	int ret= mCOMMstr::Send(m);

	do {
		m = mCOMMstr::Receive();
	} while (m.command != 297 && m.command != -1000);

	if (m.command == 297 && m.command != -999)
	{

		vec[0] = m.dArgs[0];
		vec[1] = m.dArgs[1];
		vec[2] = m.dArgs[2];
		vec[3] = m.dArgs[3];
		vec[4] = m.iArg;
		return 1;
	}
	else
	{
		return -1;
	}
}

_declspec(dllexport)int mCOMMstr::GetDynModelRotationAndScale(int dID, double vec[])
{
	int ret = mCOMMstr::Send(297, dID);


	tcpMessage m;
	do {
		m = mCOMMstr::Receive();
	} while (m.command != 297 && m.command != -1000);

	if (m.command == 297 && m.command != -999)
	{

		vec[0] = m.dArgs[0];
		vec[1] = m.dArgs[1];
		vec[2] = m.dArgs[2];
		vec[3] = m.dArgs[3];
		vec[4] = m.iArg;
		return 1;
	}
	else
	{
		return -1;
	}
}

_declspec(dllexport)int mCOMMstr::GetDynModelRotationAndScale(char* label, double vec[])
{
	tcpMessage m;
	m.storeStringInArr(label);
	m.command = 298;
	m.iArg = -1;
	int ret = mCOMMstr::Send(m);

	do {
		m = mCOMMstr::Receive();
	} while (m.command != 298 && m.command != -1000);

	if (m.command == 298 && m.command != -999)
	{

		vec[0] = m.dArgs[0];
		vec[1] = m.dArgs[1];
		vec[2] = m.dArgs[2];
		vec[3] = m.dArgs[3];
		vec[4] = m.iArg;
		return 1;
	}
	else
	{
		return -1;
	}
}



_declspec(dllexport)int mCOMMstr::GetDynModelStatus(int dID)
{
	int ret = mCOMMstr::Send(291, dID);


	tcpMessage m;
	do {
		m = mCOMMstr::Receive();
	} while (m.command != 291 && m.command != -1000);

	if (m.command == 291 && m.command != -999)
	{

		return m.iArg;
	}
	else
	{
		return -1;
	}
}

_declspec(dllexport)int mCOMMstr::GetDynModelStatus(char* label)
{
	tcpMessage m;
	m.storeStringInArr(label);
	m.command = 291;
	m.iArg = -1;
	int ret = mCOMMstr::Send(m);

	do {
		m = mCOMMstr::Receive();
	} while (m.command != 291 && m.command != -1000);

	if (m.command == 291 && m.command != -999)
	{
		return m.iArg;
	}
	else
	{
		return -1;
	}
}