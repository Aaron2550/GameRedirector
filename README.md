# GameRedirector
A simple C# Program that redirects Steam Games (And all other executables), allowing you to use **Remote Play together** on unsupported games.

## Usage
- Download the executable from GitHub Actions
- Drop it in the folder of the Game you want to replace
- Rename it to the name of the original Game
- Open Steam, right-click the original Game and set Launch Options
- Launch the Game via Steam
- ???
- Profit!

### Launch Options
`<Game to launch> [Directory to launch the Game in] [Arguments to launch the Game with]`

For Example:

`"D:\SteamLibrary\steamapps\common\GarrysMod\hl2.exe" "D:\SteamLibrary\steamapps\common\GarrysMod" "-noworkshop -noaddons"`

Note: You do not need Quotation marks around Paths and Arguments, unless they contain spaces

## Examples
### Replace Half-Life 2 with Garry's Mod
- Place `GameRedirector.exe` in `D:\SteamLibrary\steamapps\common\Half-Life 2`
- Rename `GameRedirector.exe` to `hl2.exe`
- Set Steam Launch Options to `"D:\SteamLibrary\steamapps\common\GarrysMod\hl2.exe"`
- Launching Half-Life 2 in Steam will now launch Garry's Mod, allowing you to use Remote Play Together
