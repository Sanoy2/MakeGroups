# MakeGroups application
  
  ## Purpose
  The applications is created to make online appointments easier in the case when meeting members should be split into smaller groups to work on some task (like during sprint retrospective). The application identifies the user by the domain account, so no username or password is necessary. All users can create an appointment or join to an axisting one. User cannot kick any other user from the meeting out. Each user can become a leader of small group - the users are split into as many groups as many leaders on the meeting. Every user can become a leader. Everyone can make anyone a leader or revert someones role back to member. When teams are arranges, everyone can see the teams or rearrange teams.
  ## Run the app
  Running the application is really simple, because all it needs is IIS. The application does not need any database connection or space to store logs / temporary files. It also does not need the connection to global network, so it can be hosted inside company network. The application does not store any data, does not analyze the traffic, does not communicate with other applications, does not need any settings to be replaced before production deploy - it uses the same setup when deployed in debug and release mode. All it needs is in memory cache that is cleared after 1 hour of inactivity (1 hour is the default timespan, you can change the timespan in the code before compilation).
  ### Prerequisites
  All tools you need to use (except Windows/WindowsServer system) is free of charge or even open-sourced (like .net core sdk). You can find all the prerequisites below:
  #### Development machine
  Basically everything you need to build the application is having .NET Core 3.1 SDK installed on your development machine.
  You can also build the application on a hosting machine if it has SDK package installed.
  #### Hosting machine
  * Windows/WindowsServer with IIS installed
  * Access to IIS Windows Authentication
  * ASP.NET Core Hosting Bundle 3.1 if you do not want to host the application as self-contained one
  * An user account that has access to run the application under IIS
  
  ### Deploy
  You can deploy the application the same way you deploy all other ASP.NET Core application on IIS by hand or using CI/CD environment. 
  
  There is also a short manual how to do it manually:
  1. Build the application using dotnet CLI by typing `dotnet build -c Release -o out` in your console (probably PowerShell or GitBash).
  1. Copy content of `out` directory.
  1. Create a directory for the application on your hosting machine.
  1. Paste files from `out` directory into newly created directory on your hosting machine.
  1. Create application pool for the application and choose option Runtime version: No managed code.
  1. Add web site under newly created pool, choose a path to the application and change Port to a free one that you want the application to use.
  1. Open Authentication options of the application and set: Windows authentication ENABLED. All other authentication options DISABLED
  1. Application should be running (if it is not running try starting/restarting it)
  
  ## License
  The application is shared under MIT license. You can use it, share it, implement your own features, use the code in every way you want.
  
