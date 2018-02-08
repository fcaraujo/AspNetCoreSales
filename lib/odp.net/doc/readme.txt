===================================================
ORACLE DATA PROVIDER FOR .NET 11.2.0.2.0 Production
===================================================
 Copyright (c) 2010, Oracle and/or its affiliates. All rights reserved. 

This document provides information that supplements the Oracle Data Provider 
for .NET (ODP.NET) Production documentation.


===============
IMPORTANT NOTES
===============

ODP.NET supports .NET Framework 2.0 and higher.  However, ODP.NET 11.2.0.2.0 
is not a LINQ enabled data provider.


============================
INSTALLATION AND SETUP NOTES
============================

1. Product Dependencies

ODP.NET requires Oracle Client 11.2.0.2.0 or Oracle Instant Client 11.2.0.2.0. 
When installing a new ODP.NET 11.2.0.2.0 instance, Oracle Universal Installer 
(OUI) will automatically install Oracle Instant Client 11.2.0.2.0.


2. Policy DLLs

Note that the installation of ODP.NET will place ODP.NET policy DLLS 
into the GAC so that existing applications can start using the newly 
installed ODP.NET version immediately.  However, if this is not desired, be 
sure to remove the policy DLLs from the GAC.


3. Registry Settings

ODP.NET's registry settings that are located under 
HKLM\Software\Oracle\ODP.NET\<version>
are used as default values for various configruation parameters for a specific
version of ODP.NET.  When a new version of ODP.NET is installed, a new entry
is created in the registry for that version of ODP.NET with its version
specific default values.  It will not inherit any default nor non-default 
settings that are set on the previous version of ODP.NET.  Thus, the newly 
installed version of ODP.NET needs to be configured appropriately, as needed,
after the install.


4. Home Selector

When the home selector is used to activate a specific Oracle Home, 
ODP.NET in that Oracle Home will be reconfigured.  However, policy DLLs for
newer version of ODP.NET will not be removed from the GAC.  Therefore, for 
the application to use the version of the ODP.NET that is installed in the 
selected Oracle Home, some policy DLLs may need to be removed from the GAC 
or policy DLLs need to be disabled via config files.


==============================
ORACLEPERMISSION RELATED NOTES
==============================

1. Configuring OraclePermission for Web Applications in high or medium trust

For Web Applications operating under high or medium trust, OraclePermission 
needs to be configured in the appropriate "web_<trust level>.config"  file so 
that the application does not encounter any security errors.  This 
configuration can be done through the OracProvCfg tool. OraProvCfg.exe will
make the appropriate entries in both web_hightrust.config as well as 
web_mediumtrust.config associated with the specified .NET framework version. 

Given below is an example on the usage of OraProvCfg tool for configuring 
OraclePermission in a .NET 2.0 web application:

    OraProvCfg.exe /action:config  /product:odp /component:oraclepermission 
                   /frameworkversion:v2.0.50727
                   /providerpath:<Oracle.DataAccess.dll full path>

On running the above command, The following entry will be made in  
"web_hightrust.config" and  "web_mediumtrust.config" under ASP.NET permissionset

<IPermission class="Oracle.DataAccess.Client.OraclePermission, Oracle.DataAccess, Version=2.112.1.0, Culture=neutral, PublicKeyToken=89b483f429c47342" version="1" Unrestricted="true" />

OraProvCfg can also be used to remove these entries from these config files 
when they need to be removed.

    OraProvCfg.exe /action:unconfig  /product:odp  /component:oraclepermission
                   /frameworkversion:v2.0.50727
                   /providerpath:<Oracle.DataAccess.dll full path>


2. Configuring OraclePermission For Windows Applications in partial trust

For Windows applications operating in a partial trust environment, the 
OraclePermission entry should be specified under the appropriate permission 
set in security.config file. (Security.config is available in 
%windir%\Microsoft.NET\Framework\{version}\CONFIG). The example below 
specifies the OraclePermission entry that would be required for a .NET 2.0 
Windows application

<IPermission class="Oracle.DataAccess.Client.OraclePermission, Oracle.DataAccess, Version=2.112.1.0, Culture=neutral, PublicKeyToken=89b483f429c47342" version="1" Unrestricted="true" />


==================================
TIPS, LIMITATIONS AND KNOWN ISSUES
==================================

1.  It's highly recommended not to proceed with application execution if it 
    encounters exceptions that are associated with possible memory corruption 
    issues, such as System.AccessViolationException, 
    System.Runtime.InteropServices.SEHException, etc.

2.  Data truncation errors can be encountered when fetching LONG data from a 
    UTF8 database.

3.  When using distributed transactions in conjunction with proxy connections,
    the client user password must be supplied due to an OraMTS limitation.

4.  Distributed Transactions and Isolation Levels
    ODP.NET supports only the read committed isolation level for distributed
    transactions.

5.  PL/SQL LONG, LONG RAW, RAW, VARCHAR data types cannot be bound with more 
    than 32512 bytes.

6.  Having a command execution terminated through either the invocation of 
    OracleCommand's Cancel method or expiration of OracleCommand's 
    CommandTimeout property value may return ORA-00936 or ORA-00604, rather 
    than the expected ORA-01013.

7.  An exception is not thrown when change notification is registered on a 
    bad port number.

8.  If the HKEY_LOCAL_MACHINE\Software\Oracle\NLS_LANG registry entry is 
    set to "NA", ORA-12705 errors will be encountered when using ODP.NET.  
    To eliminate this problem, remove the 
    HKEY_LOCAL_MACHINE\Software\Oracle\NLS_LANG registry entry.

9.  TimeStamp with Local Time Zone Attributes of a UDT
    Binding a custom object with an attribute of type TimeStamp with Local Time 
    Zone as a parameter is not supported in the production release.  The same 
    limitation applies for TimeStamp with Local Time Zone Elements of 
    a Collection.

10. XMLType Attributes/Elements of a UDT
    ODP.NET does not support UDTs with XMLType as an attribute or an element.

11. If SenderId is specified in OracleAQMessage object while enqueuing, the 
    sender id of dequeued message will have "@ODP.NE" appended in the end. 
    [Bug 7315542]

12. An "ORA-00942: table or view does not exist" error may be thrown from Dequeue 
    or DequeueArray method invocations when OracleAQDequeueOptions.DeliveryMode 
    is specified as OracleAQMessageDeliveryMode.Buffered and 
    OracleAQDequeueOptions.Correlation is specified and there are no messages 
    available in the queue. [Bug 7343633]

13. If the Oracle Database version is 10.1 or earlier, 
    OracleAQMessageAvailableEventArgs.QueueName is not double quoted in regular 
    (i.e. non-group) notifications. [Bug 8253957]

14. Application may not receive group notifications if GroupingInterval property 
    on the OracleNotificationRequest object is set to 0. [Bug 7373765]

15. Against 9.2 database, a message remains in WAITING state if the Delay 
    property of OracleAQMessage was set to a non-zero value while enqueuing 
    the message. [Bug 8828674]

16. AQ Notifications, Change Notifications, and HA Notifications will fail to be 
    sent from 11.2.0.1.0 DB to 11.2.0.2.0 ODP.NET. [Bug 10065474]
 
17. An "ORA-01013: user requested cancel of current operation" error is 
    encountered when an XMLType column of binary storage in an ASSM tablespace 
    is fetched from a table and then used as a parameter in XQuery. [Bug 9550954]

    