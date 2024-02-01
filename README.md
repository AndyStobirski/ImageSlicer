# Image Slicer

This app allows an image to be exported as a series of rectangles or polygons which can be either drawn onto the loaded image or detected using the AForge pacakge, and are known as **panels**.

This project was authored in Visual Studio 2022, and requires no fancy plugins or extensions, and in short should work out of the box.

This app is covered by the MIT license which is contained in the root directory of this project.

## Usage

### Creating a Project

To export an image as panel, create a project using File > New

Load an image into the project with Tools > Import Image

Save a project with File > Save or File > Save As

### Saving a Project

The image and selection panels can be saved as a project into an in individual file using File > Save or File > Save As.

### Adding panels

The panel type being drawn on a loaded image is selected from the *Shapes Menu*, which has the items Polygon or Rectangle.

**Manual drawing panels**

Click and drag to draw a panel, releasing the mouse will add the panel if it exceeds the Selection Size values, or doubleclick the image to add a panel of the selection size values. 

Panels will contain a number indicating the order in which they were added, which can be changed by selecting the panel in the property grid.

**Automatically**

A regular number of panels can be drawn on the image by selecting Tools > Generate Panels. Options available are rows, columns, vertical padding and horizontal padding.

This assumes the image has regular spaced panel, and is a quick way to get started.

**Editing Panels**

The tab panels on the main form contains a treeview of added panels and a property grid which displays various values of the selected item.

A panel can be deleted by clicking the X in the top right corner, and resized by the horizontal and vertical grab handles.

All panels can be removed can by Selecting Tools > Remove All Panels.

Polygon panels can have another point adding by clicking on a line, and a point can be removed by double clicking it.

### Exporting images

To export the images under the panels Tools > Export Panels.

The output directory, by default, is taken from the image source location, and can be changed with a folder browser.

Files are outputted in the form imagename_imageorder.png

Imagename can be specified for the panels being exported, by default is *image*.

Imageorder is set when panels are added, and can offset by specifying an offset number, by default is 1.

## To Do

Things it needs:

* Add undo / redo (I'll never do this, to be honest)
* Add a duplicate panel feature
* Add z-order
* Improve panel hit detection - it gets weird if panels are stacked on top of each other.

## Dependencies

* Newtonsoft.JSON - used in serialisation of panels