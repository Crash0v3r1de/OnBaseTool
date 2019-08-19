# OnBase Automation Tool
Simple UI tool that will wipe and reinstall OnBase if any issues happen. Plugin, driver and runtime's will also be included.


## Why is this a thing?
---
Well to be honest i have to attend to ALOT of issues related to OnBase and the always horrible OnBase plugins for Office. I've made this tool to help myself and maybe even staff to fix initial issues with OnBase.
It's pretty simple stuff i've automated so i wouldn't say this is a very big project but i think it'll help cut down on onbase troubleshooting time for everyone.

## Automation Functions
---
**Unity Uninstaller**
You'd think this would be simple but since it's a ClickOnce application the uninstall process is stored in the registry and is ran command line(not with MSI). Automatically clicks needed buttons.

**Unity Installer**
This is also simple but it's essential for the automation steps. Loads the .application through IE (maybe will change down the road) and automatically clicks the install for you.

**File and Folder Cleanup**
This isn't a crazy needed function, but OnBase does leave 2 folders and 2 files left over from an offical uninstall of Unity so this removes those.

**Virtual Print Driver Install**
Pretty simple function, checks if it is missing. If missing it'll download the zip from CU's cite, unzip, and prompt for admin to install.

**Plugin Installer**
This'll by default install the plugin upon button press. There is a checkbox to repair the plugin if it is installed that essentially removes using VSTOInstaller to remove properly then installs again as it would normally.

**Runtime Installer**
Pretty simple function, checks if it is missing. If missing it'll download the zip from CU's cite, unzip, and prompt for admin to install.

## Note
This is a very basic boring Winform UI which i will swap to a WPF after everything is set in stone code wise. Functionality first then fancy UI's later.
I've "multi threaded" the tool so the UI doesn't lock up so you can watch the progress bar and "please wait" label show up while the installs or uninstalls are finsihing.

The WPF conversion fro WinForm is on the ack burner to be honest. I've got alot to do for now so that'll be on the low low for now.
