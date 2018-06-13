﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class BL_Tasks {

    private FlagStore commonData = FlagStore.GetInstance();

    private EVAProcedure procedure;

    public EVATask previousTask;
    public EVATask currentTask;
    public EVATask nextTask;
    public EVATask repeatTask;

    public void AwakeFunction()
    {
        previousTask = new EVATask();
        currentTask = new EVATask();
        nextTask = new EVATask();
        repeatTask = new EVATask();

        procedure = new EVAProcedure();

        LoadTaskOne();
       
         //LoadProcedure2();
    }

    public EVAProcedure GetProcedure()
    {
        return procedure;
    }



    public BL_Tasks ()
    {
        AwakeFunction();
        //Example for databse - map json data to C# object
    }

    public void nextFunction(
        bool nextStep
        )
    {

        bool greenFlag = commonData.getGreen();
        bool notGreenFlag = commonData.getNotGreen();

        if (nextStep == true)
        {

            int index = commonData.currentTask.stepNumber - 1;


            if (index == procedure.tasks.Count - 1)
            {
                //do nothing we are at the end
                commonData.nextTask = new EVATask();
                commonData.currentTask = new EVATask();
                commonData.currentTask.text = "Task Complete!";
                commonData.currentTask.stepNumber = procedure.tasks.Count;
                commonData.previousTask = new EVATask();
            }
            else if (index == procedure.tasks.Count - 2)
            {
                //Go back one step only
                commonData.nextTask = new EVATask();
                commonData.currentTask = procedure.tasks[index + 1];
                commonData.previousTask = procedure.tasks[index];
            }
            else
            {

                commonData.nextTask = procedure.tasks[index + 2];
                commonData.currentTask = procedure.tasks[index + 1];
                commonData.previousTask = procedure.tasks[index];

            }



            //whatever
            previousTask = commonData.previousTask;
            currentTask = commonData.currentTask;
            nextTask = commonData.nextTask;
        }
    }

    public void nextFunction2(
        bool nextStep
        )
    {

        bool greenFlag = commonData.getGreen();
        bool notGreenFlag = commonData.getNotGreen();

        if(nextStep == true)
        {

            int index = commonData.currentTask.stepNumber - 1;


            if (index == procedure.tasks.Count-1)
            {
                //do nothing we are at the end
                commonData.nextTask = new EVATask();
                commonData.currentTask = new EVATask();
                commonData.currentTask.text = "Task Complete!";
                commonData.currentTask.stepNumber = procedure.tasks.Count;
                commonData.previousTask = new EVATask();
                commonData.setGreen(false);
                commonData.setNotGreen(false);
            }
            else if (index == procedure.tasks.Count -2)
            {
                //Go back one step only
                commonData.nextTask = new EVATask(); 
                commonData.currentTask = procedure.tasks[index +1];
                commonData.previousTask = procedure.tasks[index];
            }
            else
            {
                if (index == 29)
                {
                    commonData.nextTask = new EVATask();
                    commonData.currentTask = procedure.tasks[30];
                    commonData.previousTask = procedure.tasks[29];
                } else
                {
                    if (greenFlag == true)
                    {
                        if ((index == 30) || (index == 29))
                        {
                            commonData.nextTask = new EVATask();
                            commonData.currentTask = procedure.tasks[31];
                            commonData.previousTask = procedure.tasks[30];
                            commonData.currentTask.stepNumber = 32;
                        }

                        if (index == 31)
                        {
                            commonData.nextTask = new EVATask();
                            commonData.currentTask = new EVATask();
                            commonData.currentTask.text = "Task Complete!";
                            commonData.currentTask.stepNumber = 41;
                            commonData.previousTask = new EVATask();
                        }


                    }
                    else
                    {

                        if (notGreenFlag == true)
                        {

                            if (index == 30)
                            {
                                commonData.nextTask = procedure.tasks[34];
                                commonData.currentTask = procedure.tasks[32];
                                commonData.previousTask = new EVATask();
                                commonData.currentTask.stepNumber = 33;
                            }

                            if (index >= 32)
                            {
                                commonData.nextTask = procedure.tasks[index + 2];
                                commonData.currentTask = procedure.tasks[index + 1];
                                commonData.previousTask = procedure.tasks[index];
                            }
                        }
                        else
                        {
                            if (index < 30)
                            {
                                commonData.nextTask = procedure.tasks[index + 2];
                                commonData.currentTask = procedure.tasks[index + 1];
                                commonData.previousTask = procedure.tasks[index];
                            }
                            else
                            {
                                commonData.nextTask = new EVATask();
                                commonData.currentTask = procedure.tasks[30];
                                commonData.previousTask = procedure.tasks[29];
                            }

                        }

                    }
                }          
            }


            //whatever
            previousTask = commonData.previousTask;
            currentTask = commonData.currentTask;
            nextTask = commonData.nextTask;
        }
    }

    

    public void previousFunction(
        bool previousStep
        )
    {
        if (previousStep == true)
        {
            int index = commonData.currentTask.stepNumber-1;


            if(index == 0)
            {
                //do nothing we are at the beginning
            }
            else if (index == 1)
            {
                //Go back one step only
                commonData.nextTask = procedure.tasks[index];
                commonData.currentTask = procedure.tasks[index - 1];
                commonData.previousTask = new EVATask();
            }
            else
            {
                commonData.nextTask = procedure.tasks[index];
                commonData.currentTask = procedure.tasks[index - 1];
                commonData.previousTask = procedure.tasks[index - 2];
            }

            previousTask = commonData.previousTask;
            currentTask = commonData.currentTask;
            nextTask = commonData.nextTask;

        }
    }

    public void previousFunction2(
        bool previousStep
        )
    {
        if (previousStep == true)
        {
            int index = commonData.currentTask.stepNumber - 1;


            if (index == 0)
            {
                //do nothing we are at the beginning
            }
            else if (index == 1)
            {
                //Go back one step only
                commonData.nextTask = procedure.tasks[index];
                commonData.currentTask = procedure.tasks[index - 1];
                commonData.previousTask = new EVATask();
            }
            else
            {
                commonData.nextTask = procedure.tasks[index];
                commonData.currentTask = procedure.tasks[index - 1];
                commonData.previousTask = procedure.tasks[index - 2];
            }

            previousTask = commonData.previousTask;
            currentTask = commonData.currentTask;
            nextTask = commonData.nextTask;

        }
    }

    public void LoadTaskOne()
    {
        procedure = new EVAProcedure();
        EVATask task1 = new EVATask();
        task1.stepNumber = 1;
        task1.text = "On the RIGHT side of the EVA Kit, locate the PANEL ACCESS KEY.";
        task1.caution = "The keys are on a tension-spring cable";
        task1.warning = "";
        task1.holograms = "";
        task1.images = "";
        EVATask task2 = new EVATask();
        task2.stepNumber = 2;
        task2.text = "Use the PANEL ACCESS KEY to unlock the PANEL ACCESS DOOR LOCKS.";
        task2.caution = "";
        task2.warning = "";
        task2.holograms = "";
        task2.images = "2";
        EVATask task3 = new EVATask();
        task3.stepNumber = 3;
        task3.text = "Carefully return keys to the side of the EVA kit.";
        task3.caution = "";
        task3.warning = "";
        task3.holograms = "";
        task3.images = "";
        EVATask task4 = new EVATask();
        task4.stepNumber = 4;
        task4.text = "Insert your fingers in the CENTER OPENING and secure the PANEL ACCESS DOOR in an OPEN position.";
        task4.caution = "";
        task4.warning = "Door can accidentally close ";
        task4.holograms = "";
        task4.images = "4";
        EVATask task5 = new EVATask();
        task5.stepNumber = 5;
        task5.text = "On your belt, use the BLUE CARABINEER to securely tether to the TETHER CABLE inside the STORAGE.";
        task5.caution = "Notice the TETHER CABLE is adjustable";
        task5.warning = "";
        task5.holograms = "";
        task5.images = "";
        EVATask task6 = new EVATask();
        task6.stepNumber = 6;
        task6.text = "Locate the E-stop button, insert keys into it and turn it to off ";
        task6.warning = "";
        task6.holograms = "E-Stop";
        task6.images = "6";
        EVATask task7 = new EVATask();
        task7.stepNumber = 7;
        task7.text = "Locate the FUSIBLE DISCONNECT box";
        task7.warning = "";
        task7.holograms = "FusibleDisconnectBox";
        task7.images = "";
        EVATask task8 = new EVATask();
        task8.stepNumber = 8;
        task8.text = "Tether the BLUE CARABINEER to the TETHER CABLE";
        task8.warning = "";
        task8.holograms = "";
        task8.images = "";
        EVATask task9 = new EVATask();
        task9.stepNumber = 9;
        task9.text = "Remove the BLUE CARABINEER from the FUSIBLE DISCONNECT BOX";
        task9.warning = "";
        task9.holograms = "FusibleDisconnectBox";
        task9.images = "9";
        EVATask task10 = new EVATask();
        task10.stepNumber = 10;
        task10.text = " Transfer the BLUE CARABINEER to STORAGE";
        task10.warning = "";
        task10.holograms = "";
        task10.images = "";
        EVATask task11 = new EVATask();
        task11.stepNumber = 11;
        task11.text = " Open the FUSIBLE DISCONNECT box and secure the lid in the open position";
        task11.caution = " Pull the locking tab towards STORAGE with the thumb ";
        task11.warning = "";
        task11.holograms = "FusibleDisconnectBox";
        task11.images = "11";
        EVATask task12 = new EVATask();
        task12.stepNumber = 12;
        task12.text = "Locate the BLACK DISCONNECT";
        task12.warning = "";
        task12.holograms = "FusibleDisconnectBox";
        task12.images = "";
        EVATask task13 = new EVATask();
        task13.stepNumber = 13;
        task13.text = " Tether it to the TETHER CABLE";
        task13.warning = "";
        task13.holograms = "";
        task13.images = "";
        EVATask task14 = new EVATask();
        task14.stepNumber = 14;
        task14.text = "Remove the DISCONNECT";
        task14.caution = " Pull up with the index and middle fingers while pushing down on the FUSE ACCESS PANEL with the thumb ";
        task14.warning = "";
        task14.holograms = "FusibleDisconnectBox";
        task14.images = "14";
        EVATask task15 = new EVATask();
        task15.stepNumber = 15;
        task15.text = "Place the DISCONNECT in the STORAGE";
        task15.warning = "";
        task15.holograms = "";
        task15.images = "";
        EVATask task16 = new EVATask();
        task16.stepNumber = 16;
        task16.text = "Tether the FUSE ACCESS PANEL to the TETHER CABLE";
        task16.warning = "";
        task16.holograms = "";
        task16.images = "";
        EVATask task17 = new EVATask();
        task17.stepNumber = 17;
        task17.text = "Remove the FUSE ACCESS PANEL by pulling straght up";
        task17.warning = "";
        task17.holograms = "";
        task17.images = "17";
        EVATask task18 = new EVATask();
        task18.stepNumber = 18;
        task18.text = "Place the FUSE ACCESS PANEL into STORAGE";
        task18.warning = "";
        task18.holograms = "";
        task18.images = "";
        EVATask task19 = new EVATask();
        task19.stepNumber = 19;
        task19.text = " Tether the ALARM FUSE to the TETHER CABLE";
        task19.warning = "";
        task19.holograms = "";
        task19.images = "";
        EVATask task20 = new EVATask();
        task20.stepNumber = 20;
        task20.text = "In Storage, locate the BLUE FUSE PULLER";
        task20.warning = "";
        task20.holograms = "";
        task20.images = "";
        EVATask task21 = new EVATask();
        task21.stepNumber = 21;
        task21.text = "Use the BLUE FUSE PULLER to remove ONLY the ALARM FUSE";
        task21.caution = " Rock the ALARM FUSE with the FUSE PULLER when pulling up ";
        task21.holograms = "";
        task21.images = "21";
        EVATask task22 = new EVATask();
        task22.stepNumber = 22;
        task22.text = "Return the ALARM FUSE and the FUSE PULLER to STORAGE";
        task22.warning = "";
        task22.holograms = "";
        task22.images = "";
        EVATask task23 = new EVATask();
        task23.stepNumber = 23;
        task23.text = "In STORAGE, locate the FUSE ACCESS PANEL and reinstall it into the FUSIBLE DISCONNECT box.";
        task23.warning = "";
        task23.holograms = "FusibleDisconnectBox";
        task23.images = "23";
        EVATask task24 = new EVATask();
        task24.stepNumber = 24;
        task24.text = "Remove the FUSE ACCESS PANEL tether from the TETHER CABLE and stow inside";
        task24.warning = " All tethers are under  spring tension and can retract quickly";
        task24.caution = "";
        task24.holograms = "";
        task24.images = "";
        EVATask task25 = new EVATask();
        task25.stepNumber = 25;
        task25.text = "In STORAGE, locate the DISCONNECT and reinstall it into the FUSIBLE DISCONNECT box";
        task25.caution = "The DISCONNECT must read ON in the upper right corner to restore Conductivity";
        task25.warning = "";
        task25.holograms = "FusibleDisconnectBox";
        task25.images = "25";
        EVATask task26 = new EVATask();
        task26.stepNumber = 26;
        task26.text = " Remove the DISCONNECT tether from the TETHER CABLE";
        task26.caution = "";
        task26.warning = "All tethers are under spring tension and can retract quickly";
        task26.holograms = "";
        task26.images = "";
        EVATask task27 = new EVATask();
        task27.stepNumber = 27;
        task27.text = " Close the FUSIBLE DISCONNECT box cover";
        task27.caution = "";
        task27.warning = "";
        task27.holograms = "FusibleDisconnectBox";
        task27.images = "";
        EVATask task28 = new EVATask();
        task28.stepNumber = 28;
        task28.text = "In STORAGE, use the BLUE CARABINEER to clip and lock the FUSIBLE DISCONNECT box cover";
        task28.caution = "";
        task28.warning = "";
        task28.holograms = "FusibleDisconnectBox";
        task28.images = "28";
        EVATask task29 = new EVATask();
        task29.stepNumber = 29;
        task29.text = "Remove the BLUE CARABINEER’s tether from the TETHER CABLE";
        task29.caution = "";
        task29.warning = "All tethers are under spring tension and can retract quickly";
        task29.holograms = "";
        task29.images = "";



        procedure.tasks.Add(task1);
        procedure.tasks.Add(task2);
        procedure.tasks.Add(task3);
        procedure.tasks.Add(task4);
        procedure.tasks.Add(task5);
        procedure.tasks.Add(task6);
        procedure.tasks.Add(task7);
        procedure.tasks.Add(task8);
        procedure.tasks.Add(task9);
        procedure.tasks.Add(task10);
        procedure.tasks.Add(task11);
        procedure.tasks.Add(task12);
        procedure.tasks.Add(task13);
        procedure.tasks.Add(task14);
        procedure.tasks.Add(task15);
        procedure.tasks.Add(task16);
        procedure.tasks.Add(task17);
        procedure.tasks.Add(task18);
        procedure.tasks.Add(task19);
        procedure.tasks.Add(task20);
        procedure.tasks.Add(task21);
        procedure.tasks.Add(task22);
        procedure.tasks.Add(task23);
        procedure.tasks.Add(task24);
        procedure.tasks.Add(task25);
        procedure.tasks.Add(task26);
        procedure.tasks.Add(task27);
        procedure.tasks.Add(task28);

        commonData.previousTask = new EVATask();
        commonData.currentTask = task1;
        commonData.nextTask = task2;

        previousTask = new EVATask();
        currentTask = task1;
        nextTask = task2;

    }

    public void LoadTaskTwo()
    {
        procedure = new EVAProcedure();
        EVATask task1 = new EVATask();
        task1.stepNumber = 1;
        task1.text = "Locate the Aux. Power Input";
        task1.caution = "";
        task1.warning = "";
        task1.holograms = "Aux_PowerInput";
        task1.images = "";
        EVATask task2 = new EVATask();
        task2.stepNumber = 2;
        task2.text = "Locate BATTERY PACK and tether to TETHER CABLE";
        task2.caution = "Depress the red and black plastic hammers on the side of the AUX. POWER INPUT and pull the leads straight up";
        task2.warning = "";
        task2.holograms = "";
        task2.images = "";
        EVATask task3 = new EVATask();
        task3.stepNumber = 3;
        task3.text = "Undo the BATTERY PACK LEADS from the AUX. POWER INPUT";
        task3.caution = "";
        task3.warning = "";
        task3.holograms = "Aux_PowerInput";
        task3.images = "2.3";
        EVATask task4 = new EVATask();
        task4.stepNumber = 4;
        task4.text = "Remove BATTERY PACK from AUX. POWER INPUT";
        task4.caution = "";
        task4.warning = "";
        task4.holograms = "Aux_PowerInput";
        task4.images = "";
        EVATask task5 = new EVATask();
        task5.stepNumber = 5;
        task5.text = "Locate the ON/OFF switch on the back of the BATTERY PACK and switch it to the OFF position.";
        task5.caution = "";
        task5.warning = "";
        task5.holograms = "";
        task5.images = "2.5";
        EVATask task6 = new EVATask();
        task6.stepNumber = 6;
        task6.text = "Place the BATTERY PACK into STORAGE";
        task6.caution = "";
        task6.warning = "";
        task6.holograms = "";
        task6.images = "";
        EVATask task7 = new EVATask();
        task7.stepNumber = 7;
        task7.text = "In STORAGE, find the replacement BATTERY PACK";
        task7.caution = "";
        task7.warning = "";
        task7.holograms = "";
        task7.images = "";
        EVATask task8 = new EVATask();
        task8.stepNumber = 8;
        task8.text = "Locate the ON/OFF switch on the back of the BATTERY PACK and switch it to the ON position";
        task8.caution = "";
        task8.warning = "";
        task8.holograms = "";
        task8.images = "";
        EVATask task9 = new EVATask();
        task9.stepNumber = 9;
        task9.text = "Attach the replacement BATTERY PACK onto the AUX. POWER INPUT by the Velcro";
        task9.caution = "";
        task9.warning = "";
        task9.holograms = "Aux_PowerInput";
        task9.images = "";
        EVATask task10 = new EVATask();
        task10.stepNumber = 10;
        task10.text = "Insert the BATTERY PACK leads back into same colored ports";
        task10.caution = "Depress the red and black plastic hammers on the side of the AUX. POWER INPUT and push leads straight into their ports";
        task10.warning = "";
        task10.holograms = "";
        task10.images = "";
        EVATask task11 = new EVATask();
        task11.stepNumber = 11;
        task11.text = "Conduct a GENTLE PULL TEST on the wires";
        task11.caution = "";
        task11.warning = "";
        task11.holograms = "";
        task11.images = "";
        EVATask task12 = new EVATask();
        task12.stepNumber = 12;
        task12.text = "Remove the BATTERY PACK tether from the TETHER CABLE";
        task12.caution = "";
        task12.warning = "All tethers are under spring tension and can retract quickly";
        task12.holograms = "";
        task12.images = "";
        EVATask task13 = new EVATask();
        task13.stepNumber = 13;
        task13.text = "In STORAGE, locate the GRAY 220 Volt PLUG";
        task13.caution = "";
        task13.warning = "";
        task13.holograms = "";
        task13.images = "";
        EVATask task14 = new EVATask();
        task14.stepNumber = 14;
        task14.text = "Install it into the POWER OUT";
        task14.caution = "Outlet and plug mate are stiff, ensure the full engagement of the plug into the outlet";
        task14.warning = "";
        task14.holograms = "PowerOutputBox";
        task14.images = "2.12";
        EVATask task15 = new EVATask();
        task15.stepNumber = 15;
        task15.text = "Locate the metal BUSS BAR and verify there are BLACK, GREEN & WHITE BUSSES, each with 2 openings";
        task15.caution = "";
        task15.warning = "";
        task15.holograms = "BusBars";
        task15.images = "";
        EVATask task16 = new EVATask();
        task16.stepNumber = 16;
        task16.text = "Insert the WHITE 220 VOLT LEAD into the LEFT WHITE BUSS opening and GENTLY TIGHTEN the thumbscrew";
        task16.caution = "DO NOT over tighten the thumbscrew";
        task16.warning = "";
        task16.holograms = "";
        task16.images = "2.16";
        EVATask task17 = new EVATask();
        task17.stepNumber = 17;
        task17.text = "Insert the GREEN 220 VOLT LEAD into the LEFT GREEN BUS opening";
        task17.caution = "DO NOT over tighten the thumbscrew";
        task17.warning = "";
        task17.holograms = "";
        task17.images = "2.17";
        EVATask task18 = new EVATask();
        task18.stepNumber = 18;
        task18.text = "Insert the BLACK 220 VOLT LEAD into the LEFT BLACK BUS opening";
        task18.caution = "DO NOT over tighten the thumbscrew";
        task18.warning = "";
        task18.holograms = "";
        task18.images = "2.18";
        EVATask task19 = new EVATask();
        task19.stepNumber = 19;
        task19.text = "Make sure the METAL LEADS are not sticking out the BACK of the BUSS BAR";
        task19.caution = "";
        task19.warning = "";
        task19.holograms = "BusBars";
        task19.images = "";
        EVATask task20 = new EVATask();
        task20.stepNumber = 20;
        task20.text = "Conduct a Gentle PULL TEST on each cable";
        task20.caution = "";
        task20.warning = "";
        task20.holograms = "";
        task20.images = "";
        EVATask task21 = new EVATask();
        task21.stepNumber = 21;
        task21.text = "In STORAGE, locate the 110 VOLT PLUG";
        task21.caution = "";
        task21.warning = "";
        task21.holograms = "";
        task21.images = "2.21";
        EVATask task22 = new EVATask();
        task22.stepNumber = 22;
        task22.text = "Install it into POWER IN";
        task22.caution = "Lift cover with one hand while installing PLUG into the outlet with the other. The lid is spring-loaded";
        task22.warning = "";
        task22.holograms = "Aux_PowerInput";
        task22.images = "2.21";
        EVATask task23 = new EVATask();
        task23.stepNumber = 23;
        task23.text = "Insert the WHITE 110 VOLT PLUG LEAD into the RIGHT WHITE BUS opening";
        task23.caution = "DO NOT over tighten the thumbscrew";
        task23.warning = "";
        task23.holograms = "";
        task23.images = "2.22";
        EVATask task24 = new EVATask();
        task24.stepNumber = 24;
        task24.text = "Insert the GREEN 110 VOLT PLUG LEAD into the RIGHT GREEN BUS opening";
        task24.caution = "DO NOT over tighten the thumbscrew";
        task24.warning = "";
        task24.holograms = "";
        task24.images = "2.23";
        EVATask task25 = new EVATask();
        task25.stepNumber = 25;
        task25.text = "Insert the BLACK 110 VOLT PLUG LEAD into the RIGHT BLACK BUS opening";
        task25.caution = "DO NOT over tighten the thumbscrew";
        task25.warning = "";
        task25.holograms = "";
        task25.images = "2.24";
        EVATask task26 = new EVATask();
        task26.stepNumber = 26;
        task26.text = "Conduct a Gentle PULL TEST on each cable";
        task26.caution = "";
        task26.warning = "";
        task26.holograms = "";
        task26.images = "";
        EVATask task27 = new EVATask();
        task27.stepNumber = 27;
        task27.text = "In STORAGE, locate the E-STOP KEY";
        task27.caution = "";
        task27.warning = "";
        task27.holograms = "";
        task27.images = "2.25";
        EVATask task28 = new EVATask();
        task28.stepNumber = 28;
        task28.text = "Insert the KEY into the E-STOP and TURN it to ON position";
        task28.caution = "";
        task28.warning = "";
        task28.holograms = "E-Stop";
        task28.images = "2.26";
        EVATask task29 = new EVATask();
        task29.stepNumber = 29;
        task29.text = "Remove the KEY and place it in STORAGE";
        task29.caution = "";
        task29.warning = "";
        task29.holograms = "";
        task29.images = "";
        EVATask task30 = new EVATask();
        task30.stepNumber = 30;
        task30.text = "Locate the AUX. POWER SWITCH on the POWER IN box and switch it to the “ON” position";
        task30.caution = "";
        task30.warning = "";
        task30.holograms = "Aux_PowerInput";
        task30.images = "2.28";
        EVATask task31 = new EVATask();
        task31.stepNumber = 31;
        task31.text = "Can you please say whether the SYSTEM GO indicator light is GREEN or NOT GREEN?";
        task31.caution = "";
        task31.warning = "";
        task31.holograms = "";
        task31.images = "2.last";
        EVATask task32 = new EVATask();
        task32.stepNumber = 32;
        task32.text = "EVA 1, this is Houston Mission Control. Congratulations. PHALCON is reporting that they are reading a successful power restoration on their console. You are a go to untether from the TETHER CABLE and return to space station. Mission Control out";
        task32.caution = "";
        task32.warning = "";
        task32.holograms = "";
        task32.images = "";
        EVATask task33 = new EVATask();
        task33.stepNumber = 33;
        task33.text = "EVA 1, this is Houston Mission Control. PHALCON confirms and is not able to report a successful power restoration on their console. EVA-1, please be advised that we have prepared some trouble-shooting steps for you to conduct on a future spacewalk";
        task33.caution = "";
        task33.warning = "";
        task33.holograms = "";
        task33.images = "";
        EVATask task34 = new EVATask();
        task34.stepNumber = 34;
        task34.text = "There might be problem with power going into the circuit, Please go through the following check points";
        task34.caution = "";
        task34.warning = "";
        task34.holograms = "";
        task34.images = "";
        EVATask task35 = new EVATask();
        task35.stepNumber = 35;
        task35.text = "BATTERY PACK is switched OFF";
        task35.caution = "";
        task35.warning = "";
        task35.holograms = "";
        task35.images = "";
        EVATask task36 = new EVATask();
        task36.stepNumber = 36;
        task36.text = "BATTERY PACK leads are not inserted into their ports";
        task36.caution = "";
        task36.warning = "";
        task36.holograms = "";
        task36.images = "";
        EVATask task37 = new EVATask();
        task37.stepNumber = 37;
        task37.text = "220V PLUG or leads where not installed correctly";
        task37.caution = "";
        task37.warning = "";
        task37.holograms = "";
        task37.images = "";
        EVATask task38 = new EVATask();
        task38.stepNumber = 38;
        task38.text = "110V PLUG or leads where not installed correctly";
        task38.caution = "";
        task38.warning = "";
        task38.holograms = "";
        task38.images = "";
        EVATask task39 = new EVATask();
        task39.stepNumber = 39;
        task39.text = "AUX. POWER SWITCH is in the OFF position";
        task39.caution = "";
        task39.warning = "";
        task39.holograms = "";
        task39.images = "";
        EVATask task40 = new EVATask();
        task40.stepNumber = 40;
        task40.text = "E-STOP is still engaged";
        task40.caution = "";
        task40.warning = "";
        task40.holograms = "";
        task40.images = "";
        EVATask task41 = new EVATask();
        task41.stepNumber = 41;
        task41.text = "Batteries in the BATTERY PACK are depleted";
        task41.caution = "";
        task41.warning = "";
        task41.holograms = "";
        task41.images = "";


        procedure.tasks.Add(task1);
        procedure.tasks.Add(task2);
        procedure.tasks.Add(task3);
        procedure.tasks.Add(task4);
        procedure.tasks.Add(task5);
        procedure.tasks.Add(task6);
        procedure.tasks.Add(task7);
        procedure.tasks.Add(task8);
        procedure.tasks.Add(task9);
        procedure.tasks.Add(task10);
        procedure.tasks.Add(task11);
        procedure.tasks.Add(task12);
        procedure.tasks.Add(task13);
        procedure.tasks.Add(task14);
        procedure.tasks.Add(task15);
        procedure.tasks.Add(task16);
        procedure.tasks.Add(task17);
        procedure.tasks.Add(task18);
        procedure.tasks.Add(task19);
        procedure.tasks.Add(task20);
        procedure.tasks.Add(task21);
        procedure.tasks.Add(task22);
        procedure.tasks.Add(task23);
        procedure.tasks.Add(task24);
        procedure.tasks.Add(task25);
        procedure.tasks.Add(task26);
        procedure.tasks.Add(task27);
        procedure.tasks.Add(task28);
        procedure.tasks.Add(task29);
        procedure.tasks.Add(task30);
        procedure.tasks.Add(task31);
        procedure.tasks.Add(task32);
        procedure.tasks.Add(task33);
        procedure.tasks.Add(task34);
        procedure.tasks.Add(task35);
        procedure.tasks.Add(task36);
        procedure.tasks.Add(task37);
        procedure.tasks.Add(task38);
        procedure.tasks.Add(task39);
        procedure.tasks.Add(task40);
        procedure.tasks.Add(task41);


        commonData.previousTask = new EVATask();
        commonData.currentTask = task1;
        commonData.nextTask = task2;

        previousTask = new EVATask();
        currentTask = task1;
        nextTask = task2;
    }
}




