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
5. Copy the folder [/Project/Emotion/](/shash678/COMP241Project/Project/Emotion/) as this is the main project file.
6. If wanting to rebuild the visualiser, rebuild and edit the paths in the following files:
	* Lines [122 and 123](/shash678/COMP241Project/blob/master/Project/Emotion/main.py#L122-L133) to the locations of the desired output (122 for song files and 123 for the CSV file)
	* Lines [156 and 157](/shash678/COMP241Project/blob/master/Project/Emotion/main.py#L156-L157) to the executabe to star the visualiser
7. Read about issues
8. Run [main.py](/shash678/COMP241Project/Project/Emotion/main.py)

If you have any issues, feel free to contact Brent.

## Issues
Currently the visualiser cannot take in dynamic input for audio. CSV files are still read in dynamically and will change based on what song is selected when the visualise button is clicked.

This means music that was used in the building of the visualiser will be the only audio that the vislaiser plays, however the data that the visualiser reads from the CSV to manipulate some functions will still be used.

More information of this can be found [here](/shash678/COMP241Project/Project/Visualiser/).

To temprarily fix this so incorrect data is not displayed can be easily fixed by commenting out lines [153 to 155 in main.py](/shash678/COMP241Project/blob/master/Project/Emotion/main.py#L153-L155). This will disable the CSV wrting so the original CSV file will still be passing the correct data.

## Authors
* Dylan Exton: Background code
* Ryan Le Quesne: GUI development
* Brent Vollebregt: Background code
* Jack Woods: Machine Learning
