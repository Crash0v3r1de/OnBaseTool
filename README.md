# OnBase Automation Tool
Simple UI tool that will wipe and reinstall OnBase if any issues happen. Plugin, driver and runtime's will also be included.


## Why is this a thing?
---
Well to be honest i have to attend to ALOT of issues related to OnBase and the always horrible OnBase plugins for Office. I've made this tool to help myself and maybe even staff to fix initial issues with OnBase.
It's pretty simple stuff i've automated so i wouldn't say this is a very big project but i think it'll help cut down on onbase troubleshooting time.

## Automation Functions
---
**Unity Uninstaller**
You'd think this would be simple but since it's a ClickOnce application the uninstall process is stored in the registry and is ran command line. Automatically clicks needed buttons.

**Unity Installer**
This is also simple but it's essential for the automation steps. Loads the .application through IE (maybe will change down the road) and automatically clicks the install.

**File and Folder Cleanup**
This isn't a crazy needed function but OnBase does leave 2 folders and 2 files left over from an offical uninstall of Unity so this removes those.

**Virtual Print Driver Install**
This will be added at some point. It'll just download, extract and install the driver automatically. (will need Admin elevation)

**Plugin Installer**
This will be added at some point. It'll do as the unity client. Load and automatically install the plugin's specificed.

**Runtime Installer**
This will be added at some point. It'll download, extract and install the required runtime libraries for the plugins.

## Note
This is a very basic boring Winform UI which i will swap to a WPF after everything is set in stone code wise. Functionality first then fancy UI's later.
I also will be multithreading the tool after everything is good so the UI doesn't lock up and i can show simple status info. (not that it's needed but might as well add it)
