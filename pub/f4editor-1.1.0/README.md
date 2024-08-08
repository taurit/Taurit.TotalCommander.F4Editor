# f4editor (Total Commander plugin)

```txt
Version: 1.1
Project URL: https://github.com/taurit/Taurit.TotalCommander.F4Editor
Release date: 2024-08-08
Author: Tim Taurit
```

## Description

F4editor is a convenience tool that selects most suitable program for Edit action (traditionally triggered by F4 key) in Total Commander, instead of using the same editor for all files.

## How it works?

You just need to set is as default editor in Total Commander by going to *Configuration -> Options -> Edit/View* and setting your "Editor for F4" like this:

```cmd
d:\path\to\f4editor.exe "d:\path\to\your\f4config.json" "%1"
```

If that's set up, pressing F4 will launch f4editor application. It will then read your config file and open your editor of choice for the specific file based on its extension.

## Configuration

Code below is an example of a configuration file content, which contains user's preferred editors.

```json
{
  "DefaultEditor": {
    "EditorPath": "notepad.txt"
  },
  "EditorConfigurations": [
    {
      "EditorPath": "c:\\Program Files (x86)\\Microsoft VS Code\\Code.exe",
      "ExtensionList": "json;xml;html;htm;md"
    },
    {
      "EditorPath": "c:\\Program Files\\paint.net\\PaintDotNet.exe",
      "ExtensionList": "png;bmp;jpg;jpeg;gif"
    }
  ]
}
```

## Dependencies

This build only depends on .NET Framework 4.8. It's installed in Windows by default since Windows 8.
