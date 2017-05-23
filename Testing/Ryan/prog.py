import sys, os
from PyQt5 import QtCore, QtGui, QtWidgets
from music2 import Ui_musicGUI

class MusicGuiProgram(Ui_musicGUI):
        def __init__(self, dialog):
                Ui_musicGUI.__init__(self)
                self.setupUi(dialog)

                # Connect "Browse" button with open file dialog
                self.buttonLoad.clicked.connect(self.readFiles)
                # Connect List widget with the toggle recommended method
                self.listWidget.currentItemChanged.connect(self.toggleRecommended)
                
                #read from the folder of the program
                for file in os.listdir('.'):
                        if file.endswith((".mp3",'.wav','.ogg','.flac')):
                                file = file.rpartition('.')[0]
                                self.listWidget.addItem(file)

        def readFiles(self):
                #use a system open file dialog to select a number of music files
                files = QtWidgets.QFileDialog.getOpenFileNames(dialog, 'Open file', '', "Music (*.mp3 *.wav *.ogg #.flac)")[0]
                self.listWidget.clear()
                #split the string such that only the filename is included (it is the whole directory by default)
                for file in files:      
                        file = file.rpartition('/')[-1]
                        file = file.rpartition('.')[0]
                        self.listWidget.addItem(file)   #add each item to the list box

        #This method is called whenever the selected item of the music listbox changes
        #Thus, the recommended list is to be reproduced every time
        def toggleRecommended(self):
                self.listWidgetRec.clear()
                try:
                        self.listWidgetRec.addItem(self.listWidget.currentItem().text())
                except:
                        print("")

if __name__ == '__main__':
        app = QtWidgets.QApplication(sys.argv)
        dialog = QtWidgets.QDialog()

        prog = MusicGuiProgram(dialog)

        dialog.show()
        sys.exit(app.exec_())
