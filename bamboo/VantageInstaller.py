# required ENV Python 3.7 & pip install requests 
# execute command python3 bamboo/VantageInstaller.py commercial
import requests
import re
from datetime import datetime
import time
import urllib
import os
import zipfile
import os
import shutil
import sys


BASE_URL = "https://artifactory.tc.lenovo.com/artifactory/lenovo-auto-delete-generic-local/Vantage/uwp/release/"
ZIP_FILE_NAME = "vantage"
IS_COMMERCIAL = sys.argv[1].lower() == 'commercial'

def getLatestPath(url):
    response = requests.get(url).text

    result = re.findall(r"<a href\=.*\">(.*)?</a>(.*)? -", response)
    if not result:
        result = re.findall(r"<a href\=.*\">(.*)?</a>(.* MB)", response)
    paths = []
    dates = []
    for path, date in result:
        if url.endswith("release/"):
            if IS_COMMERCIAL and not path.startswith("vantage-le"):
                continue
            if not IS_COMMERCIAL and  path.startswith("vantage-le"):
                continue
        paths.append(path)
        dateString = date
        if "MB" in date: 
            dateArray = date.split()
            dateString = dateArray[0] + " " + dateArray[1]
        else:
            dateString = re.match("^ +(.*?) +$", date).group(1)
        timestamp = time.mktime(datetime.strptime(dateString, "%d-%b-%Y %H:%M").timetuple())
        dates.append(timestamp)
    value = paths[dates.index(max(dates))]
    return value

def getCorrectUrl(basedUrl):
    url = basedUrl
    while ".zip" not in url:
        url = url + getLatestPath(url)
    return url

def prepareVantage(url):
    if os.path.isfile(ZIP_FILE_NAME):
        os.remove(ZIP_FILE_NAME)
    print("Start download zip file")
    urllib.request.urlretrieve(url, ZIP_FILE_NAME)
    print("Finish download zip file")

    package_path = "./bamboo/AppPackages"
    if os.path.isdir(package_path):
        shutil.rmtree(package_path)
    print("unzip file " + ZIP_FILE_NAME)
    with zipfile.ZipFile(ZIP_FILE_NAME, 'r') as zip_ref:
        zip_ref.extractall("./bamboo")


    for x in os.listdir(package_path):
        if ("VantageShell" in x) & (not x.endswith("upload")):
            return os.path.dirname(os.path.abspath(__file__)) + "\\AppPackages\\" + x + "\Add-AppDevPackage.ps1"

url = getCorrectUrl(BASE_URL)
print("Download URL is: " + url)
os.system("echo . | powershell \"Get-AppxPackage *Lenovo* | Remove-AppxPackage\"")
print("Uninstall vantage")
os.system("echo . | powershell " + prepareVantage(url))
print("Install vantage")
print("all done")
