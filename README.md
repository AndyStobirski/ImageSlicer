# Image Slicer

This app allows an image to be exported as a series of rectangles which are drawn onto the loaded image, and are known as **panels**.

This project was authored in Visual Studio 2022, and requires no fancy plugins or extensions, and in short should work out of the box.

This app is covered by the MIT license which is contained in the root directory of this project.

## Usage

### Opening a file

Select File > Open to select an image to display.

### Adding panels

**Manual**

Click and drag to draw a panel, releasing the mouse will add the panel if it exceeds the Selection Size values, or doubleclick the image to add a panel of the selection size values. 

Panels will contain a number indicating the order in which they were added, which can be changed by selecting the panel in the property grid.

**Automatically**

The tab settings on the main form contains a section called *Generate Panels*, which is used to automatically generate a set of panels on the loading images. The number of panels per row and number of columns can be specified, along with horizontal and vertical panel paddings. This assumes the image has regular spaced panel, and is a quick way to get started.

**Editing Panerls**

The tab panels on the main form contains a treeview of added panels and a property grid which displays various values of the selected item.

A panel can be deleted by clicking the X in the top right corner, and resized by the horizontal and vertical grab handles.

All panels can be removed can by Selecting Edit > Remove All Panels.

### Exporting images

To generate a series of regular panels select Tools > Export Images.

The output directory, by default, is taken from the image source location, and can be changed with a folder browser.

Files are outputted in the form imagename_imageorder.png

Imagename can be specified for the panels being exported, by default is *image*.

Imageorder is set when panels are added, and can offset by specifying an offset number, by default is 1.

## To Do

Things it needs:

* Add a polygon shape for non-rectangular images.
* Add feature to save panel maps
* Add undo / redo (I'll never do this, to be honest)
* Add a duplicate panel feature
* Add z-order
* Improve panel hit detection - it gets weird if panels are stacked on top of each other.