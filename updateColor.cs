using System;
using System.IO; 
using System.Text.RegularExpressions; 

public class CPHInline
{
	
	public string backgroundFilePath; 
	public string variableName; //the name of the variable in the CSS we want to change. In this case, the color of the background. 
	public string newColor; 
	
	public bool Execute()
	{
		backgroundFilePath = @"C:\Users\joshu\Desktop\Scrolling Backgrounds\heartscroller.html"; //maybe this should look different :) 
		variableName = "--main-bg-color"; 
		newColor = args["rawInput"].ToString(); //what the user inputs from twitch
		
		if(!checkIfValidColor(newColor) && !checkIfHex(newColor))
		{
			newColor = "red"; 
			CPH.SendMessage("That was not a valid color! Defaulting to red", true); 
		}
		
		if(checkIfHex(newColor))
		{
			CPH.SendMessage("You entered a hex code? How complicated...", true); 
		}
		
		
		//search through the file, find the variable, and replace it with the input. 
		string[] fileLines = File.ReadAllLines(backgroundFilePath);
		for(int i = 0; i < fileLines.Length; i++)
		{
			if(fileLines[i].Contains(variableName))
			{
				string[] parts = fileLines[i].Split(':');
				if(parts.Length == 2)
				{
					string variablePart = parts[0].Trim(); 
					fileLines[i] = $"{variablePart}: {newColor};";
					break; 
				} 
			}
		} 
		
		File.WriteAllLines(backgroundFilePath, fileLines); 
		
		CPH.ObsSendRaw("PressInputPropertiesButton", "{'inputName': 'Pixel Scrolling Background', 'propertyName': 'refreshnocache'}", 0);

		
		
		return true;
	}
	
	public bool checkIfHex(string possibleColor)
	{
		Regex hexColorRegex = new Regex(@"^#([0-9A-Fa-f]{6}|[0-9A-Fa-f]{3})$");
		return hexColorRegex.IsMatch(possibleColor); 
	}
	
	
	public bool checkIfValidColor(string possibleColor)
	{
		string[] cssNamedColors = {
            "aliceblue", "antiquewhite", "aqua", "aquamarine", "azure",
            "beige", "bisque", "black", "blanchedalmond", "blue",
            "blueviolet", "brown", "burlywood", "cadetblue", "chartreuse",
            "chocolate", "coral", "cornflowerblue", "cornsilk", "crimson",
            "cyan", "darkblue", "darkcyan", "darkgoldenrod", "darkgray",
            "darkgreen", "darkgrey", "darkkhaki", "darkmagenta", "darkolivegreen",
            "darkorange", "darkorchid", "darkred", "darksalmon", "darkseagreen",
            "darkslateblue", "darkslategray", "darkslategrey", "darkturquoise", "darkviolet",
            "deeppink", "deepskyblue", "dimgray", "dimgrey", "dodgerblue",
            "firebrick", "floralwhite", "forestgreen", "fuchsia", "gainsboro",
            "ghostwhite", "gold", "goldenrod", "gray", "green",
            "greenyellow", "grey", "honeydew", "hotpink", "indianred",
            "indigo", "ivory", "khaki", "lavender", "lavenderblush",
            "lawngreen", "lemonchiffon", "lightblue", "lightcoral", "lightcyan",
            "lightgoldenrodyellow", "lightgray", "lightgreen", "lightgrey", "lightpink",
            "lightsalmon", "lightseagreen", "lightskyblue", "lightslategray", "lightslategrey",
            "lightsteelblue", "lightyellow", "lime", "limegreen", "linen",
            "magenta", "maroon", "mediumaquamarine", "mediumblue", "mediumorchid",
            "mediumpurple", "mediumseagreen", "mediumslateblue", "mediumspringgreen", "mediumturquoise",
            "mediumvioletred", "midnightblue", "mintcream", "mistyrose", "moccasin",
            "navajowhite", "navy", "oldlace", "olive", "olivedrab",
            "orange", "orangered", "orchid", "palegoldenrod", "palegreen",
            "paleturquoise", "palevioletred", "papayawhip", "peachpuff", "peru",
            "pink", "plum", "powderblue", "purple", "rebeccapurple",
            "red", "rosybrown", "royalblue", "saddlebrown", "salmon",
            "sandybrown", "seagreen", "seashell", "sienna", "silver",
            "skyblue", "slateblue", "slategray", "slategrey", "snow",
            "springgreen", "steelblue", "tan", "teal", "thistle",
            "tomato", "turquoise", "violet", "wheat", "white",
            "whitesmoke", "yellow", "yellowgreen"
        };
        
        possibleColor = possibleColor.ToLower().Trim(); 
        int indexOfColor = Array.IndexOf(cssNamedColors, possibleColor); 
        if(indexOfColor > 0){
        	return true; 
        	}
        else{
			return false; 
        }
	}
}
