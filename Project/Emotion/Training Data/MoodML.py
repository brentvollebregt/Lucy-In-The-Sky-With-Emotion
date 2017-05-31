from sklearn import datasets
from sklearn import svm
from sklearn import metrics
import pandas as pd


datapanda = pd.read_csv('x_train.csv', sep=',',header=None)
datafig = pd.read_csv('y_train.csv', sep=',', header=None)

datanew = datafig.T
print(datapanda.describe())
print(datapanda.values)

print(datanew.values)

print(datanew.shape)

clf = svm.SVC(gamma = 0.001, C = 100)

#clf.fit(datapanda.values[200:860], datanew.values[200:860])
#print("PREDICTION:")
#print(clf.predict(datapanda.values[-1:]))
