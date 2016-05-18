import java.awt.Image
import java.awt.image.BufferedImage
import javax.imageio.ImageIO

def iconSizes = [
    // iOS
    57,
    72,
    76,
    114,
    120,
    144,
    152,
    180,

    // Android
    36,
    48,
    72,
    96,
    144,
    192,
]

if (args.size() != 1) {
    println("usage : groovy create_icons.groovy YOUR_ICON_IMAGE_NAME")
    return
}

def imagePath = args[0]
def inputImage = ImageIO.read(new File(imagePath))

iconSizes.each { iconSize ->
    def iconName = "icon${iconSize}x${iconSize}.png"
    createResizedIcon (inputImage, iconName, iconSize, iconSize)
}

def createResizedIcon (def inputImage, def outputFilename, def width, def height) {
    def outputFile = new File(outputFilename)
    def scaledImage = inputImage.getScaledInstance(width,height,Image.SCALE_SMOOTH)

    def bufferedImage = new BufferedImage((int)scaledImage.width,(int)scaledImage.height,BufferedImage.TYPE_4BYTE_ABGR)
    def graphics = bufferedImage.getGraphics();
    graphics.drawImage(scaledImage,0,0,null)
    graphics.dispose()

    ImageIO.write(bufferedImage,'PNG',outputFile)
}