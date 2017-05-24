import sys, os, emotion_helper
from PyQt5 import QtCore, QtGui, QtWidgets
from music2 import Ui_musicGUI

#default directory is the current working directory, overwritten on use of import button
global directory
directory = os.getcwd()

class MusicGuiProgram(Ui_musicGUI):
        def __init__(self, dialog):
                Ui_musicGUI.__init__(self)
                self.setupUi(dialog)

                # Connect "Browse" button with open file dialog
                self.buttonLoad.clicked.connect(self.openFiles)
                # Connect List widget with the toggle recommended method
                self.listWidget.currentItemChanged.connect(self.recommend)
                # Connect "visualise" button with the visualiser method
                self.buttonVisual.clicked.connect(visualise)
                
                #read from the folder of the program on GUI load
                #uncomment to re-enable
                
                #for file in os.listdir('.'):
                #        if file.endswith((".mp3",'.wav','.ogg','.flac')):
                #                file = file.rpartition('.')[0]
                #                self.listWidget.addItem(file)

        def openFiles(self):
                #use a system open file dialog to select a number of music files
                files = QtWidgets.QFileDialog.getOpenFileNames(dialog, 'Open file', '', "Music (*.mp3 *.wav *.ogg *.flac)")[0]
                self.listWidget.clear()

                #else the directory is wherever the user opens a file
                #this line simply cuts off the end of a file path to give just the directory
                directory = files[0].replace(files[0].rpartition('/')[-1],'')
                
                #split the string such that only the filename is included (it is the whole directory by default)
                for file in files:      
                        file = file.rpartition('/')[-1]
                        file = file.rpartition('.')[0]
                        self.listWidget.addItem(file)   #add each item to the list box

        #This method is called whenever the selected item of the music listbox changes
        #Thus, the recommended list is to be reproduced every time
        def recommend(self):
                self.listWidgetRec.clear()
                
                selected = self.listWidget.currentItem().text() #currently selected item
                index = self.listWidget.currentRow()            #index of the currently selected item (may be useful)
                
                recSongs = []
                #code to generate recommended list will go here
                
                try:
                        for item in recSongs:
                                self.listWidgetRec.addItem(item)
                except:
                        print("")

def visualise():
        # Call visualise()
        print("Yo yo")

def import_dir():
        data = emotion_helper.import_from_dir(directory)
        tagged_data = []
        for file in data:
                tagged_data.append(emotion_helper.get_tags(file))
        
        uri_data = []
        for file in tagged_data:
                uri_data.append(emotion_helper.get_uri(file))
        
        uri_index = emotion_helper.int_index_to_uri_index(uri_data)
        
        spotify_data = emotion_helper.get_spotify_data(uri_index)
        # Write the data to tge GUI based off the data in spotify_data (Brent and Ryan)
        return None

def mood(song):
        # Call get_mood()
        pass
        

if __name__ == '__main__':
        app = QtWidgets.QApplication(sys.argv)
        dialog = QtWidgets.QDialog()

        prog = MusicGuiProgram(dialog)

        dialog.show()
        sys.exit(app.exec_())
