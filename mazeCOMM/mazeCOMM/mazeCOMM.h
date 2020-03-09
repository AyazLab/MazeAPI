/*
MazeSuite API Header
Adrian Curtin, Hasan Ayaz


All rights reserved
see license.txt for more information
*/

#include "stdafx.h"

#ifndef EXPORT
#define EXPORT
#endif

struct mCOMMstr
{
	EXPORT __declspec(dllexport)int Connected();
	EXPORT __declspec(dllexport)int Listen(int port);
	EXPORT __declspec(dllexport)int ListenFromParams();
	EXPORT __declspec(dllexport)int ListenFromParams(char* filename);

	EXPORT __declspec(dllexport)int SendCue();
	EXPORT __declspec(dllexport)int Jump();
	EXPORT __declspec(dllexport)int BoundedMovement(bool enable);
	EXPORT __declspec(dllexport)int EnableGravity(bool enable);
	EXPORT __declspec(dllexport)int MoveForward(double dist);
	EXPORT __declspec(dllexport)int MoveBackward(double dist);
	EXPORT __declspec(dllexport)int LookLeft(double angle);
	EXPORT __declspec(dllexport)int LookRight(double angle);
	EXPORT __declspec(dllexport)int StrafeLeft(double dist);
	EXPORT __declspec(dllexport)int StrafeRight(double dist);
	EXPORT __declspec(dllexport)int LogVal(int iArg);
	EXPORT __declspec(dllexport)int LogString(char* input);
	EXPORT __declspec(dllexport)int SendAlert(char* input,int dispTime);
	EXPORT __declspec(dllexport)int NextLevel();
	EXPORT __declspec(dllexport)int PlayerInteract();
	EXPORT __declspec(dllexport)int SetScore(int iArg);
	EXPORT __declspec(dllexport)int SetPosition(double xPos,double yPos,double zPos,double angle);
	EXPORT __declspec(dllexport)int GetPosition(double vec[]);
	EXPORT __declspec(dllexport)int GetNextMarker(int* code, int*val);
	EXPORT __declspec(dllexport) int SetMoveSpeed(bool setToDefault);
	EXPORT __declspec(dllexport) int SetMoveSpeed(bool setToDefault, double moveSpeed);

	EXPORT __declspec(dllexport) int GetElapsedTime();
	EXPORT __declspec(dllexport) int GetStatus();
	EXPORT __declspec(dllexport) int GetStatus(char* statusStr);
	EXPORT __declspec(dllexport) int GetCurrentMazeName(char* mazeName);

	EXPORT __declspec(dllexport)int InstantSetScore(int iArg);
	EXPORT __declspec(dllexport)int GetScore();
	EXPORT __declspec(dllexport)int Pause();
	EXPORT __declspec(dllexport)int Disconnect();

			//Joystick Emulation
	EXPORT	__declspec(dllexport)int SetNetJoystickX(int val);
	EXPORT	__declspec(dllexport)int SetNetJoystickY(int val);
	EXPORT	__declspec(dllexport)int SetNetJoystickZ(int val);
	EXPORT	__declspec(dllexport)int SetNetJoystickR(int val);
	EXPORT	__declspec(dllexport)int SetNetJoystick(int netX,int netY,int netZ,int netR);
	EXPORT	__declspec(dllexport)int ClearNetJoystick();

			//Dynamic Object manipulation
	EXPORT	__declspec(dllexport)int SetDynModelPos(int dynID, double xPos, double yPos, double zPos);
	EXPORT	__declspec(dllexport)int SetDynModelRotationScale(int dynID, double xRot, double yRot, double zRot, double scale);
	EXPORT	__declspec(dllexport)int SetDynModelToNewModel(int dynID, int newModelID);
	EXPORT	_declspec(dllexport)int GetDynModelIDbyLabel(char* label);
	EXPORT	_declspec(dllexport)int GetDynModelPositionAndModel(int dID, double vec[]);
	EXPORT	_declspec(dllexport)int GetDynModelPositionAndModel(char* label, double vec[]);
	EXPORT	_declspec(dllexport)int GetDynModelRotationAndScale(int dID, double vec[]);
	EXPORT	_declspec(dllexport)int GetDynModelRotationAndScale(char* label, double vec[]);
};

struct tcpMessage
{
	int command;	//Command code
	int iArg;		//int argument
	double dArgs[4]; //double arguments 
};


