# Project-Option-VR Network communication test
Unity version 2021.1.26f1

Compatible with most version of Unity

Airplane physique model is based on https://github.com/gasgiant/Aircraft-Physics 

Network communication is realized through Mirror https://mirror-networking.gitbook.io/docs/

## Project demonstration

The goal of our option's project is to realize the commnunication between mobile phone and computer, and get familiar with the sensors on a mobile phone, like accelerator, gyroscope, microphone, etc. 

Originally, this is done with bluetooth. However, the bluetooth component in Unity is too expensive for us, so we chose to use the open-source network component Mirror to finish our project.

This project is done in two part, the communication part, and the environment part. We haven't these two parts yet, so here is only the communicaiton part.

## Guide of the project
Because we can't develop a IOS application (which requires an Apple developper's account), so this project is based on Android.

1. Import unity project, then build the project in the File -> Build setting -> Android -> Build (Generate an .apk file for Android phone).

![Screenshot 2022-01-03 at 22 31 32](https://user-images.githubusercontent.com/82207694/147982554-32bae4f3-91ff-47fc-a289-8617eccb9cb8.png)![Screenshot 2022-01-03 at 22 40 49](https://user-images.githubusercontent.com/82207694/147983412-8c1ffff9-77ab-424b-b0b3-344e43661ec9.png)


2. Once installed the application on an android phone, make sure that the computer and the phone is under the same network.

![Screenshot 2022-01-03 at 22 34 22](https://user-images.githubusercontent.com/82207694/147982928-133c91ab-0852-46b1-8866-23ac55d575bf.png)

3. Open application on the phone, and also launch it in unity.

   On computer, click "Server Only".
   
   ![147983029-350a15a3-9cde-4004-a56a-8cbfafa60946](https://user-images.githubusercontent.com/82207694/147983570-54705b17-669e-4c02-9e50-700a070810da.png)


   On the phone, type the IP address of the computer into the blank next to the "Client" button, then click "Client".
   
   ![Screenshot 2022-01-03 at 22 39 49](https://user-images.githubusercontent.com/82207694/147983649-235c3406-9e2b-4835-828a-ef49e7a09aff.png)


4. Normally, the phone is connect with the computer, and you can see the plane on the phone too. If the variables for the plane pitch, roll, and yaw do not change for the first time, try to "Stop client" on the phone, and click "Client" again. This may be due to the initialization of the gyroscope. The second time will work fine.

   Control of flap remains of the computer, "F" the change flap. (Rarely used)

5. Tap the screen with 5 fingers to start the engine. Tap again to shut it down.

   Make some noise to accelerate (blow into the microphone or just tap it).

   Tap the screen with 3 or 4 fingers to brake.

   Tap and hold with 1 or 2 fingers to aim.  Release the fingers to shoot.
