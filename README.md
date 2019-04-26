# TwitchSongSync
Collaboratively enter the lyrics to the song in time to the song in the chat.


## Overview
The general idea for this program comes from some livestreamers allowing for song requests in the form of donations. This program allows you to connect to your friends, and collaboratively enter the lyrics to the song you requested in the livestream chat as it plays.

### Features
* Import a CSV file to define the lyrics and timestamps.
* Adjust the order that people say each line of the lyrics.
* Choose an optional prefix and suffix for each line.
  * For example, to cheer 1 twitch bit at the start of every line of the lyrics, enter "`cheer1 `" as the prefix.
    * Yes, that includes the space after it.
* Define where the livestream chat is on your screen.


## Guide

### The CSV file
The CSV file defines each line of the lyrics that are said, and at what time that line is said.
It should be formatted so that each row represents a line of the lyrics, with the first column of each row being the amount of seconds after the start that this line is said, and with the second column of each row being the line to be said.

![CSV Example](/images/CSV.png)

### Mouse Setup
Click the `Run Mouse Setup Wizard` button to define where the livestream chat message box is.
After doing this, it is very important that you don't cover up the livestream chat message box or move the window the holds the livestream chat message box, as this will cause the program to click in the wrong place when it tries to enter the lyrics.


## Example of Usage
* 3 people are connected to each other. Person 1 is the host.
* They decide to donate Rick Astley's Never Gonna Give You Up as a song donation.
* Person 1 starts hosting, making sure to port forward beforehand to ensure Person 2 and Person 3 can connect to them.
  * Person 2 and Person 3 connects to Person 1.
* Person 1 imports a CSV file that defines each lyric line, and the timestamp that lyric line is said.
* Person 1 adds a suffix to all lines of "` cheer2`" so that on every lyric line they cheer 2 bits after it.
* All 3 people run the Mouse Setup Wizard to define where Twitch's message box is on their monitor.
  * After doing this, they make sure that they don't move their browser window with Twitch in it, and they make sure the Twitch message box is visible on their screen.
* Person 1 adjusts the order so that Person 2 goes first, then Person 1, then Person 3.
* Person 1 makes sure everyone is ready, then tells Person 2 to send the song donation.
* Person 1 gets ready, and as soon as the song starts playing on stream, they hit the start button.
* The song starts playing on stream, and on the correct cue, the lyrics are entered into the Twitch chat:
  * Person 2: `We're no strangers to love cheer2`
  * Person 1: `You know the rules and so do I cheer2`
  * Person 3: `A full commitment's what I'm thinking of cheer2`
  * Person 2: `You wouldn't get this from any other guy cheer2`
  * Person 1: `I just wanna tell you how I'm feeling cheer2`
  * and so on...
