def colorHexaStringList = ["ffffff", "ffff00" ,"ff00ff", "ff0000" ,"00ffff", "00ff00" ,"0000ff", "000000"]
def sizeStringList = ["150x100", "100x100", "320x240", "180x400"]

[colorHexaStringList, sizeStringList].combinations().each { colorHexaString, sizeString ->
    def url = "http://placehold.jp/${colorHexaString}/${colorHexaString}/${sizeString}.png"
    def fileName = "${colorHexaString}_${sizeString}.png"

    new File(fileName) << new URL(url).openStream()
}