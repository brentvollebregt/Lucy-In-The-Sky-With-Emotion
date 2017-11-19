# Lucy In The Sky With Emotion
COMP241-17A project for visualizing emotions in songs

This project was split into two halves, an emotion detection and a visualiser.

The emotion project can be found at [/Emotion/](https://github.com/shash678/COMP241Project/tree/master/Emotion). This contains the python files to run the emotion side.

The visualiser project can be found at [/Visualiser/](https://github.com/shash678/COMP241Project/tree/master/Visualiser). This contains the necessary files to build the visualiser in unity

To run the project, the visualiser project will need to be built and the python emotion detection script will need to be given the location of the built visualiser.

## Authors
* [Rhys Compton](https://github.com/basedrhys)
* [Dylan Exton](https://github.com/DylanExton)
* [Ryan Le Quesne](https://github.com/ryancomp241)
* [Seattle Tupuhi](https://github.com/minionsattle)
* [Brent Vollebregt](https://github.com/brentvollebregt)
* [Jack Woods](https://github.com/Woodsy1FD)

## Project Managers
* [Swikrit Khanal](https://github.com/swikrit)
* [Sash Sinha](https://github.com/shash678)

# Emotion Detection In Music

## Settings.json
Remember to edit settings.json

Go to https://developer.spotify.com/my-applications/ and make an app to get your keys as we are not allowed to distribute our own keys.

## Layout
* main.py: Imports GUI and links modules, does all functions
* GUI.py: Stores GUI code
* emotion_helper.py: Modules needed to do large activities in main.py

## Requirements
* requests (pip install requests)
* matplotlib (pip install matplotlib)
* mutagen (pip install mutagen)
* pyqt5 (pip install pyqt5)
* scipy (Get http://www.lfd.uci.edu/~gohlke/pythonlibs/#scipy then run 'pip install <package>')
* numpy+mkl (Get http://www.lfd.uci.edu/~gohlke/pythonlibs/#numpy then run 'pip install <package>')
* sklearn (pip install scikit-learn)
* pandas (pip install pandas)

## Installation Instructions
1. Install python 3.5 (3.5.2 if you want to know a specific version, but it can be any).
2. If using Windows, run install_dependencies.bat. If not using windows, run the pip commands in the bat file. This will install most of the modules.
3. Install scipy by first dowloading it at http://www.lfd.uci.edu/~gohlke/pythonlibs/#scipy and then running 'pip install <file>'.
4. Install numpy+mkl by first dowloading it at http://www.lfd.uci.edu/~gohlke/pythonlibs/#numpy and then running 'pip install <file>'.
5. Copy the folder [/Emotion/](https://github.com/shash678/COMP241Project/blob/master/Emotion/) as this is the main project file.
6. Build the visualiser and edit the paths in the following files in main.py:
	* Lines [123 and 125](https://github.com/shash678/COMP241Project/blob/master/Emotion/main.py#L122-L125) to the locations of the desired output (123 for song files and 125 for the CSV file)
	* Line [156](https://github.com/shash678/COMP241Project/blob/master/Emotion/main.py#L159) to the executabe to star the visualiser
7. Read about issues
8. Run [main.py](https://github.com/shash678/COMP241Project/blob/master/Emotion/main.py)

If you have any issues, feel free to contact Brent.

## Issues
Currently the visualiser cannot take in dynamic input for audio. CSV files are still read in dynamically and will change based on what song is selected when the visualise button is clicked.

This means music that was used in the building of the visualiser will be the only audio that the vislaiser plays, however the data that the visualiser reads from the CSV to manipulate some functions will still be used.

To temprarily fix this so incorrect data is not displayed can be easily fixed by commenting out lines [153 to 155 in main.py](https://github.com/shash678/COMP241Project/blob/master/Emotion/main.py#L155-L157). This will disable the CSV wrting so the original CSV file will still be passing the correct data.

# Visualisation of Music
Instructions need to be added
