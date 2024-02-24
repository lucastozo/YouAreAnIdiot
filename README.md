# YouAreAnIdiot

This is a recreation of the YouAreAnIdiot "malware" made with Windows Forms. It won't cause any direct damage to your computer, but it will overload its resources and force you to restart.

## How to run
There's two versions of the program, one written on .NET Core 8.0 and one written on .NET Framework 4.7.2, even though .NET Core is more modern than .NET Framework, i recommend using the .NET Framework version because it runs on almost any Windows PC without needing to install anything extra.

> .NET Core 8.0
> 
> `git clone git clone https://github.com/lucastozo/YouAreAnIdiot.git`

> .NET Framework 4.7.2 (recommended)
> 
> `git clone -b dotnet-framework https://github.com/lucastozo/YouAreAnIdiot.git`

Open the solution, build and run the program.

## Notes

 - The program creates a file named `youareanidiot.txt` in your
   `C:\Users\Public\` folder. Make sure to delete the file after closing
   the program.
   
 - Press the **P** key to stop the program and close all its
   instances.
