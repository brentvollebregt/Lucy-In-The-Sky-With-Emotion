# Emotion Detection In Music

## Settings.json

Remember to edit settings.json

Go to https://developer.spotify.com/my-applications/ and make an app to get your keys.

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

## Authors

* Dylan Exton: Background code
* Ryan Le Quesne: GUI development
* Brent Vollebregt: Background code
* Jack Woods: Machine Learning

### Possible Ideas

* Display all data on a graph and be able to right click on a song and hit 'show' (or something like it). This will then grey out al data except for the colour of the mood for this song.
* Make a playlist; show a graph for user to pick two points and select max amount of songs. Then calculate playlist near the line and give playlist.
