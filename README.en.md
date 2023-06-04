
# Opus Translation Tool and Patcher

| Spanish Readme | Latest Release |
|-------|----------
|[![es](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/Domivat24/OpusTools/main/README.md) | [![Download](https://img.shields.io/github/release/Domivat24/OpusTools.svg?maxAge=3600&label=download&include_prereleases)](https://github.com/Domivat24/OpusTools/releases)

This is an incomplete translation tool and patcher for the videogame Opus: Rocket of Whispers made in C# and working on Windows.

![Opus Tool showcase](https://github.com/Domivat24/OpusTools/assets/103245345/a09599cc-4bdd-46f0-97fa-0cc475515ba1)

# Usage
In order to apply the patch, you need Internet connection to download the required files and a valid installation of the game.
The application searches in the user Steam Libraries for the gamePath; if is not found, it will tell the user to manually add the route of the game in the settings Tab.
## To make your own translation
**Important:** For the time being, in order to extract the text of the game you first need to apply the patch (even if you don't care about the spanish translation). When applying the patch and succesfully booting the game until the menu is shown, a `cacheDataBase.json` will have been created on the root folder of the game. 

Now, in the tools section of the application, you can convert the text of the game to a PO fie, being able to choose which language you want to translate from and which other language you want to have as a reference in form of a comment of each entry.
When the translation is done, you can use the app to parse it as a json and put it in the root folder of the game. 

Take into account that I have not found a way to modify the font as of now, so if your language uses any special characters not found in the original game, they will not be found.

To modify the display message of the language menu, for the time being it is only possible to do so manually. You can use a tool to modify assembies such as [dnSpyEx](https://github.com/dnSpyEx/dnSpy). You just need to open dnSpy and load the `Assembly-Csharp.dll` found on `Opus Rocket of Whispers_data/Managed`, go to the `Heaven.UILanguageView` and modify the following line of the Awake function:


```csharp
languageSetting.txtLang = "YOURDESIREDLANGUAGE";
```

![menu](https://github.com/Domivat24/OpusTools/assets/103245345/df7622d2-0455-4408-a234-f6de100a4e41)

## License
[MIT](https://choosealicense.com/licenses/mit/)

## Disclaimer
The developer of this application does not have any affiliation with SIGONO and doesn't make responsible of unexpected behaviour of the application, use at your own discretion.

