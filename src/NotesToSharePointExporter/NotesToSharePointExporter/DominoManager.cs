using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace NotesToSharePointExporter
{
    public class DominoManager
    {
        public DominoManager()
        {
            NotesSession LNSession = new NotesSession();
            Domino.NotesDatabase LNDatabase;
            Domino.NotesDocument LNDocument;
            //Initialize your Session with your Password
            LNSession.Initialize("password");

            //Connect to your Notes Server and the path of your 
            //.nsf File (in my case its in a subfolder 'mail').
            LNDatabase = LNSession.GetDatabase("Notes-Server", "mail\\user.nsf", false);
            //Create an in memory document in the server database
            LNDocument = LNDatabase.CreateDocument();
            //-------Assign Field Values-------
            //Define Start&End Date+Time of your appointment
            //Year, Month, Day, Hour, Minute and Second
            System.DateTime StartDate = new DateTime(2008, 3, 19, 8, 2, 0);
            System.DateTime EndDate = new DateTime(2008, 3, 19, 8, 5, 0);
            //This Defines that it is an Calendar Entry
            LNDocument.ReplaceItemValue("Form", "Appointment");
            //Type of the appointment, means:
            LNDocument.ReplaceItemValue("AppointmentType", "0");
            //0 = Date, Appointment           
            //1 = Anniversary
            //2 = All Day Event (Do Not Set Time Here!)
            //3 = Meeting
            //4 = Reminder
            //5 = Date (Special, experimental!)    
            // Title of your entry
            LNDocument.ReplaceItemValue("Subject", "hello world");

            // Set Confidential Level (Public=1 or Private=0) 
            LNDocument.ReplaceItemValue("$PublicAccess", "1");

            //Add Start&End Time of your event
            LNDocument.ReplaceItemValue("CALENDARDATETIME", StartDate);
            LNDocument.ReplaceItemValue("StartDateTime", StartDate);
            LNDocument.ReplaceItemValue("EndDateTime", EndDate);
            LNDocument.ReplaceItemValue("StartDate", StartDate);
            LNDocument.ReplaceItemValue("MeetingType", "1");
            //Infos in The Body
            LNDocument.ReplaceItemValue("Body", "Body Text Body Text ...");
            //Add an alarm to your appointment
            LNDocument.ReplaceItemValue("$Alarm", 1);
            LNDocument.ReplaceItemValue("$AlarmDescription", "hello world (alarm)");
            LNDocument.ReplaceItemValue("$AlarmMemoOptions", "");
            //5 = Time (in minutes) before alarm goes on
            LNDocument.ReplaceItemValue("$AlarmOffset", 5);
            LNDocument.ReplaceItemValue("$AlarmSound", "tada");
            LNDocument.ReplaceItemValue("$AlarmUnit", "M");
            //This saves your Document in the Notes Calendar
            LNDocument.ComputeWithForm(true, false);
            LNDocument.Save(true, false, false);

        }
    }
}
