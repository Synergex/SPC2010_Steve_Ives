# SPC2010_Steve_Ives<br />
**Created Date:** 10/11/2010<br />
**Last Updated:** 10/11/2010<br />
**Description:** This ZIP file contains the code for various demo applications presented by Steve Ives from the Synergex Professional Services Group during the SPC2010 conference.<br />
**Platforms:** Windows<br />
**Products:** Synergy DBL; Synergy .NET; xfServerPlus; xfNetLink .NET; C#<br />
**Minimum Version:** 9.5.1<br />
**Author:** Steve Ives
<hr>

**Additional Information:**
Unzipping the Files
-------------------

Some aspects of this demo environment assume that the folders are in a known location,
C:\SPC2010_Steve_Ives\... If this is not the case you may have to do some level of
configuration, particularly in:

* Project properties for the SynergyComponent Workbench project (Component information dialog)

What's Included
---------------

SynergyServer An xfServerPlus development environment used to develop and maintain
several Synergy methods. These methods all include attributes and
doc comments which enable the Synergy Method Catalog (SMC) to be
populated autopmatically. The demo includes a batch fle called
LoadSynergyServerSMC.bat which demonstrates how to load the SMC,
and there is an entry in the Workbench BUild menu called "Load SMC
from Code" which executes this batch file. There is also an example
of a Synergy .NET Component project which is an easy way to go from
Synergy method code to a compiled xfNetLink .NET assembly which
exposes the functionality of the Synergy methods to .NET applications.

Silverlight An example of a Silverlight 4 application which uses xfNetLink .NET
and xfServerPlus. There are two projects, the Silverlight application,
and an ASP.NET web site that hosts the application. The web site also
includes a Web Service, and a WCF service, one of which is used directly
by the Silverlight application.

MonoWinformsDemo This is an example of a simple Framework 2.0 WinForms application which
uses xfNetLink .NET and xfServerPlus to communicate with Synergy. This
application was demonstrated to work on both Fedora Linux and Mac OS X,
using the Mono environment.

iPhoneDemo This is an example of an iPhone app developed in C# with MonoDevelop,
MonoTouch and C#. To do anything with this demo you will need to have
the same tools available, and you MUST be on an up-to-date Intel-based
Mac. DO NOT TRY TO USE THESE FILES IN VISUAL STUDIO - IT WON'T WORK!!!


What You Will Need
------------------
If you want to actually try to build and run all of these demos, you will need:

For the xfServerPlus with attributes environment:

Synergy/DE 9.4.3 beta (or later) including xfServerPlus and xfNetLink .NET

To build the xfNetLink .NET Assembly in Workbench

Visual Studio 2010 with C# installed
.NET Framework 4.0

To develop with the the Silverlight demo

Internet Information Server configured to run Framework 4.0
Visual Studio 2010
Silverlight 4 SDK and Silverlight 4 Toolkit

To work with / run the iPhone demo

Intel Mac with the latest Apple developer tools and SDK's installed
Latest Mono runtime (Framework)
Latest Mono
MonoTouch (eval version should be OK)


Configuring xfServerPlus
------------------------
In order to run some of the demos you will need to configure xfServerPlus:

Port: 2366
DBLDIR: Set it to your 32-bit dbl\bin folder)
XFPL_INIPATH C:\SPC2010_Steve_Ives\SynergyServer\xfpl
