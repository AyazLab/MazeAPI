using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MazeRemote
{
    class mazeCOMM
    {
        public bool connected;
        public int port;
        public mazeCOMM() 
        {
            port = 6350;
            connected = false;
        }


		//Connection
        [DllImport("mazeCOMM.DLL", EntryPoint = "?Connected@mCOMMstr@@QAEHXZ")]
        public static extern int Connected();
        [DllImport("mazeCOMM.DLL", EntryPoint = "?Listen@mCOMMstr@@QAEHH@Z")]
	    public static extern int Listen(int port);
        [DllImport("mazeCOMM.DLL", EntryPoint = "?ListenFromParams@mCOMMstr@@QAEHXZ")]
		public static extern int ListenFromParams();
		[DllImport("mazeCOMM.DLL", EntryPoint = "?ListenFromParams@mCOMMstr@@QAEHPAD@Z")]
		unsafe public static extern int ListenFromParams(StringBuilder filename);
        [DllImport("mazeCOMM.DLL", EntryPoint = "?Disconnect@mCOMMstr@@QAEHXZ")]
		public static extern int Disconnect();
        
		
		//Misc
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SendCue@mCOMMstr@@QAEHXZ")]
	    public static extern int SendCue();
        [DllImport("mazeCOMM.DLL", EntryPoint = "?LogVal@mCOMMstr@@QAEHH@Z")]
        public static extern int LogVal(int iArg);
        [DllImport("mazeCOMM.DLL", EntryPoint = "?LogString@mCOMMstr@@QAEHPAD@Z")]
        unsafe public static extern int LogString(StringBuilder input);
        [DllImport("mazeCOMM.DLL", EntryPoint = "?SendAlert@mCOMMstr@@QAEHPADH@Z")]
        unsafe public static extern int SendAlert(StringBuilder input, int dispTime);		
        [DllImport("mazeCOMM.DLL", EntryPoint = "?Pause@mCOMMstr@@QAEHXZ")]
        public static extern int Pause();
        [DllImport("mazeCOMM.DLL", EntryPoint = "?NextLevel@mCOMMstr@@QAEHXZ")]
        public static extern int NextLevel();
		
		[DllImport("mazeCOMM.DLL", EntryPoint = "?GetPosition@mCOMMstr@@QAEHQAN@Z")]
	    public static extern int GetPosition(double[] vec);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetPosition@mCOMMstr@@QAEHNNNN@Z")]
		public static extern int SetPosition(double xPos, double yPos, double zPos, double angle);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetPosX@mCOMMstr@@QAEHN@Z")]
        public static extern int SetPosX(double xPos);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetPosY@mCOMMstr@@QAEHN@Z")]
        public static extern int SetPosY(double yPos);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetPosZ@mCOMMstr@@QAEHN@Z")]
        public static extern int SetPosZ(double zPos);
		
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetMoveSpeed@mCOMMstr@@QAEH_N@Z")]
        public static extern int SetMoveSpeed(bool setToDefault);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetMoveSpeed@mCOMMstr@@QAEH_NN@Z")]
        public static extern int SetMoveSpeed(bool setToDefault, double moveSpeed);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?EnableGravity@mCOMMstr@@QAEH_N@Z")]
        public static extern int EnableGravity(bool enable);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetRotation@mCOMMstr@@QAEHN@Z")]
        public static extern int SetRotation(double angle);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?GetNextMarker@mCOMMstr@@QAEHPAH0@Z")]
        public static extern int GetNextMarker(int[] code, int[] val);
		
		//Movement
			//Metered Movement
		[DllImport("mazeCOMM.DLL", EntryPoint = "?BoundedMovement@mCOMMstr@@QAEH_N@Z")]
        public static extern int BoundedMovement(bool enable);

        [DllImport("mazeCOMM.DLL", EntryPoint = "?MoveForward@mCOMMstr@@QAEHN@Z")]
	    public static extern int MoveForward(double dist);
        [DllImport("mazeCOMM.DLL", EntryPoint = "?MoveBackward@mCOMMstr@@QAEHN@Z")]
	    public static extern int MoveBackward(double dist);
        [DllImport("mazeCOMM.DLL", EntryPoint = "?LookLeft@mCOMMstr@@QAEHN@Z")]
        public static extern int LookLeft(double angle);
        [DllImport("mazeCOMM.DLL", EntryPoint = "?LookRight@mCOMMstr@@QAEHN@Z")]
        public static extern int LookRight(double angle);
        [DllImport("mazeCOMM.DLL", EntryPoint = "?StrafeLeft@mCOMMstr@@QAEHN@Z")]
        public static extern int StrafeLeft(double dist);
        [DllImport("mazeCOMM.DLL", EntryPoint = "?StrafeRight@mCOMMstr@@QAEHN@Z")]
        public static extern int StrafeRight(double dist);
			
			//Joystick Emulation
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetNetJoystick@mCOMMstr@@QAEHHHHHH@Z")]
        public static extern int SetNetJoystick(int netX, int netY, int netZ,int netR);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetNetJoystickX@mCOMMstr@@QAEHH@Z")]
        public static extern int SetNetJoystickX(int val);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetNetJoystickY@mCOMMstr@@QAEHH@Z")]
        public static extern int SetNetJoystickY(int val);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetNetJoystickZ@mCOMMstr@@QAEHH@Z")]
        public static extern int SetNetJoystickZ(int val);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetNetJoystickR@mCOMMstr@@QAEHH@Z")]
        public static extern int SetNetJoystickR(int val);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?ClearNetJoystick@mCOMMstr@@QAEHXZ")]
        public static extern int ClearNetJoystickX();
			
			//Other Movement
        [DllImport("mazeCOMM.DLL", EntryPoint = "?Jump@mCOMMstr@@QAEHXZ")]
	    public static extern int Jump();
		
		//Interaction
        [DllImport("mazeCOMM.DLL", EntryPoint = "?SetScore@mCOMMstr@@QAEHH@Z")]
        public static extern int SetScore(int iArg);
        [DllImport("mazeCOMM.DLL", EntryPoint = "?InstantSetScore@mCOMMstr@@QAEHH@Z")]
	    public static extern int InstantSetScore(int iArg);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?GetScore@mCOMMstr@@QAEHXZ")]
        public static extern int GetScore();
		[DllImport("mazeCOMM.DLL", EntryPoint = "?PlayerInteract@mCOMMstr@@QAEHXZ")]
        public static extern int PlayerInteract();

		//Dynamic Object Manipulation
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetDynModelPos@mCOMMstr@@QAEHHNNN@Z")]
        public static extern int SetDynModelPos(int dynID, double xPos, double yPos, double zPos);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetDynModelRotationScale@mCOMMstr@@QAEHHNNNN@Z")]
        public static extern int SetDynModelRotationScale(int dynID, double xRot, double yRot, double zRot, double scale);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?SetDynModelToNewModel@mCOMMstr@@QAEHHH@Z")]
        public static extern int SetDynModelToNewModel(int dynID, int newModelID);
		
		[DllImport("mazeCOMM.DLL", EntryPoint = "?GetDynModelIDbyLabel@mCOMMstr@@QAEHPAD@Z")]
        unsafe public static extern int GetDynModelIDbyLabel(StringBuilder label);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?GetDynModelPositionAndModel@mCOMMstr@@QAEHHQAN@Z")]
        public static extern int GetDynModelPositionAndModel(int dID, double[] vec);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?GetDynModelPositionAndModel@mCOMMstr@@QAEHPADQAN@Z")]
        unsafe public static extern int GetDynModelPositionAndModel(StringBuilder label, double[] vec);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?GetDynModelRotationAndScale@mCOMMstr@@QAEHHQAN@Z")]
        public static extern int GetDynModelRotationAndScale(int dID, double[] vec);
		[DllImport("mazeCOMM.DLL", EntryPoint = "?GetDynModelRotationAndScale@mCOMMstr@@QAEHPADQAN@Z")]
        unsafe public static extern int GetDynModelRotationAndScale(StringBuilder label, double[] vec);

		
		






		
    }
}
