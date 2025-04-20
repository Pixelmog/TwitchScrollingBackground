# TwitchScrollingBackground
This project is to allow users to use a channel point redemption in order to update the background color on a twitch stream. 

Originally, this was based on png files that Streamer.Bot would update the html file with. 
The heart scrolling png could be replaced with any seamless pattern. Users can type in a color, and the program will check to see if it is a valid CSS color to use. 

The updated version uses SVG shapes. Users can type in a color with a channel point redemption to change the background color or the color of the shape. This information is sent from Streamer.Bot to the browser source html file with a websocket. Currently the only shape is a star. 
