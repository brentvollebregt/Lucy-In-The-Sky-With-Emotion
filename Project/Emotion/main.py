import sys, os, emotion_helper
from PyQt5 import QtCore, QtGui, QtWidgets
from GUI import Ui_musicGUI
import json
from shutil import copyfile
import csv

class MusicGuiProgram(Ui_musicGUI):
    def __init__(self, dialog):
        Ui_musicGUI.__init__(self)
        self.setupUi(dialog)

        # Connect "Browse" button with open file dialog
        self.buttonLoad.clicked.connect(self.openFiles)
        # Connect List widget with the toggle recommended method
        self.listWidget.currentItemChanged.connect(self.recommend)
        # Connect "visualise" button with the visualiser method
        self.buttonVisual.clicked.connect(self.visualise)

        self.data = {}
        self.reference_table = {}
        self.current_uri = ""

    def openFiles(self):
        #use a system open file dialog to select a directory
        directory = QtWidgets.QFileDialog.getExistingDirectory(dialog, "QFileDialog.getExistingDirectory()")
        self.listWidget.clear()
        data = emotion_helper.import_from_dir(directory)
        tagged_data = []
        for file in data:
            tagged_data.append(emotion_helper.get_tags(file))

        uri_data = []
        count = 0
        for file in tagged_data:
            count += 1
            print ("\r" + str(round((count/len(tagged_data))*100, 2)) + "%", end='')
            tmp = emotion_helper.get_uri(file)
            if tmp != None: # Have to remove songs which don't have search results
                uri_data.append(emotion_helper.get_uri(file))
            else:
                print (file['title'] + " - " + file['artist'] + " not found")

        uri_index = emotion_helper.int_index_to_uri_index(uri_data)

        self.data = emotion_helper.get_spotify_data(uri_index)
        for song in self.data:
            self.reference_table[self.data[song]['title'] + " - " + self.data[song]['artist']] = song
            self.listWidget.addItem(self.data[song]['title'] + " - " + self.data[song]['artist'])
        self.listWidget.sortItems()
        return True

    #This method is called whenever the selected item of the music listbox changes
    #Thus, the recommended list is to be reproduced every time
    def recommend(self):
        self.listWidgetRec.clear()

        selected = self.listWidget.currentItem().text() #currently selected item
        self.current_uri = self.reference_table[selected]

        recSongs = emotion_helper.get_recommended(self.current_uri, self.data)

        for song in recSongs:
            self.listWidgetRec.addItem(self.data[song]['title'] + " - " + self.data[song]['artist'])

        # TODO Generate mood data and append data to a new widget when Ryan has created it

        return True

    def visualise(self):
        if self.current_uri == "":
            print ("No song selected [make dialog]")
            return

        csv_output = [["number", "title", "artist", "bpm", "energy", "valence", "song_length", "original_file_location"]]
        csv_output.append([1,
                           self.data[self.current_uri]['title'],
                           self.data[self.current_uri]['artist'],
                           self.data[self.current_uri]['bpm'],
                           self.data[self.current_uri]['energy'],
                           self.data[self.current_uri]['valence'],
                           emotion_helper.get_length_of_file(self.data[self.current_uri]['file_location']),
                           self.data[self.current_uri]['file_location']
                           ])

        recSongs = emotion_helper.get_recommended(self.current_uri, self.data)

        currentIndex = 1
        for song in recSongs:
            currentIndex += 1
            csv_output.append([currentIndex,
                               self.data[song]['title'],
                               self.data[song]['artist'],
                               self.data[song]['bpm'],
                               self.data[song]['energy'],
                               self.data[song]['valence'],
                               emotion_helper.get_length_of_file(self.data[song]['file_location']),
                               self.data[song]['file_location']
                               ])

        visualiser_assets_folder = os.getcwd() + "/assestfile/"

        for song in csv_output[1:]:
            copyfile(song[7], visualiser_assets_folder + str(song[0]) + ".mp3")

        with open("visualiser_data.csv", "w", newline='') as csv_file:
            writer = csv.writer(csv_file)
            writer.writerows(csv_output)

        # Call visualise()
        print("Yo yo")


if __name__ == '__main__':
    app = QtWidgets.QApplication(sys.argv)
    dialog = QtWidgets.QDialog()

    prog = MusicGuiProgram(dialog)

    dialog.show()
    sys.exit(app.exec_())
