# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'music.ui'
#
# Created by: PyQt5 UI code generator 5.8.2
#
# WARNING! All changes made in this file will be lost!

from PyQt5 import QtCore, QtGui, QtWidgets

class Ui_musicGUI(object):
    def setupUi(self, musicGUI):
        musicGUI.setObjectName("musicGUI")
        musicGUI.setEnabled(True)
        musicGUI.resize(649, 607)
        self.buttonLoad = QtWidgets.QPushButton(musicGUI)
        self.buttonLoad.setGeometry(QtCore.QRect(220, 80, 75, 31))
        self.buttonLoad.setObjectName("buttonLoad")
        self.title = QtWidgets.QLabel(musicGUI)
        self.title.setGeometry(QtCore.QRect(40, 10, 161, 31))
        self.title.setStyleSheet("font: 14pt \"MS Shell Dlg 2\";\n"
"text-decoration: underline;")
        self.title.setScaledContents(True)
        self.title.setAlignment(QtCore.Qt.AlignCenter)
        self.title.setWordWrap(False)
        self.title.setObjectName("title")
        self.listWidget = QtWidgets.QListWidget(musicGUI)
        self.listWidget.setGeometry(QtCore.QRect(40, 140, 256, 401))
        self.listWidget.setObjectName("listWidget")
        self.label = QtWidgets.QLabel(musicGUI)
        self.label.setGeometry(QtCore.QRect(40, 60, 171, 81))
        self.label.setWordWrap(True)
        self.label.setObjectName("label")
        self.label_2 = QtWidgets.QLabel(musicGUI)
        self.label_2.setGeometry(QtCore.QRect(360, 50, 141, 71))
        self.label_2.setObjectName("label_2")
        self.listWidgetRec = QtWidgets.QListWidget(musicGUI)
        self.listWidgetRec.setGeometry(QtCore.QRect(350, 140, 256, 181))
        self.listWidgetRec.setObjectName("listWidgetRec")
        self.textBrowser = QtWidgets.QTextBrowser(musicGUI)
        self.textBrowser.setGeometry(QtCore.QRect(350, 340, 256, 201))
        self.textBrowser.setObjectName("textBrowser")

        self.retranslateUi(musicGUI)
        QtCore.QMetaObject.connectSlotsByName(musicGUI)

    def retranslateUi(self, musicGUI):
        _translate = QtCore.QCoreApplication.translate
        musicGUI.setWindowTitle(_translate("musicGUI", "Music GUI"))
        self.buttonLoad.setText(_translate("musicGUI", "Browse"))
        self.title.setText(_translate("musicGUI", "Emotion Detection"))
        self.label.setText(_translate("musicGUI", "Music is automatically loaded from the directory of the program. Use the \'browse\' button to select a different directory"))
        self.label_2.setText(_translate("musicGUI", "Recommended Songs:"))
        self.textBrowser.setHtml(_translate("musicGUI", "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0//EN\" \"http://www.w3.org/TR/REC-html40/strict.dtd\">\n"
"<html><head><meta name=\"qrichtext\" content=\"1\" /><style type=\"text/css\">\n"
"p, li { white-space: pre-wrap; }\n"
"</style></head><body style=\" font-family:\'MS Shell Dlg 2\'; font-size:8.25pt; font-weight:400; font-style:normal;\">\n"
"<p style=\" margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px; -qt-block-indent:0; text-indent:0px;\">Possibly take the valence and energy values of a selected song and then choose another song which lies within an <span style=\" font-size:8pt;\">arbitrarily </span>close distance on the plane (up, down, left, right) to that currently selected song.</p>\n"
"<p style=\"-qt-paragraph-type:empty; margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px; -qt-block-indent:0; text-indent:0px;\"><br /></p>\n"
"<p style=\" margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px; -qt-block-indent:0; text-indent:0px;\">Note, currently the program is directly pulling from music files, not any other data. If data were to be provided (csv such as name, energy, valence perhaps?), the music files themselves would not be browsed by this program.</p></body></html>"))


if __name__ == "__main__":
    import sys
    app = QtWidgets.QApplication(sys.argv)
    musicGUI = QtWidgets.QDialog()
    ui = Ui_musicGUI()
    ui.setupUi(musicGUI)
    musicGUI.show()
    sys.exit(app.exec_())

