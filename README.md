# Projet-RV-Test
//Unity version 2021.1.26f1
#Compatible with most version of Unity


Because we can't develop a IOS application, so this project is based on Android.

Import unity project, then build the project in the File -> Build setting -> Android -> Build.

Once installed the application on an android phone, make sure that the computer and the phone is under the same network.

Open application on the phone, and also launch it in unity.

On computer, click "Server Only".

On the phone, type the IP address of the computer into the blank next to the "Client" button, then click "Client".

Normally, the phone is connect with the computer, and you can see the plane on the phone too. If the variables for the plane pitch, roll, and yaw do not change,
try to "Stop client" on the phone, and click "Client" again. This may be due to the initialization of the gyroscope. The second time will work fine.

Control of the throttle and flap remains of the computer. "Space" the change the throttle, and "F" the change flap.
