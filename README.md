# Cropper
__Point and Shoot Screen Captures__

Cropper is a screen capture utility written in C#. It makes it fast and easy to grab parts of your screen. Use it to easily crop out sections of vector graphic files such as Fireworks without having to flatten the files or open in a new editor. Use it to easily capture parts of a web site, including text and images. It's also great for writing documentation that needs images of your application or web site. 

## Default Hot Keys
* Arrow keys: Nudge the main form one pixel.
* Alt + Arrow keys: Resize the main form one pixel.
* Alt + ] or Alt + [ : Resize the thumbnail indicator one pixel.
*  +Ctrl: Changes the amount of resizes and nudges listed above to ten pixels. 
* ],[ or Mouse Wheel: Resize the main form twenty pixels while keeping the crosshairs centered.
* Right Click: Context menu on the main form.
* Double Click or Enter or S: Take a screen shot of the area under the Cropper window or start/stop a recording plug-in.
* Tab: Cycle form colors.
* Shift + Tab: Cycle form sizes.
* Esc: Hide the main form.
* Ctrl + F8: Show the main form.

If Cropper is being used to save Print Screen images (Cropper will capture even while the crop form is minimized)
* PrintScreen: Take a screen shot of the entire desktop or start/stop a recording plug-in.
* Alt+PrintScreen: Take a screen shot of the current active window or start/stop a recording plug-in.
* Ctrl{"+"}Alt{"+"}PrintScreen: Take a screen shot of the region below the mouse or start/stop a recording plug-in.

## Output Options
Cropper is able to output images to a variety of formats. There is an extensibility model allowing developers to create custom output plug-ins. Descriptions of some of the default plug-ins are given below.

* BMP: Large files but no compression artifacts.
* PNG: Smaller files with lossless compression, good for most image formats except full color photographic. Think of it as a replacement for the simpler GIF format. All modern browsers can display a png file.
* JPEG: Good for full color photographic images. Cropper can save jpg's in varying quality settings from 10 to 100. 10 being the lowest quality and smallest file size. 100 being the highest quality and largest file size. A quality setting of 60-70 is usually good for the web. It's a good trade off between file size and image quality.
* Clipboard: The image is placed on the clipboard and can be pasted into any application that accepts images.
* Printer: Presents a print dialog that allows you to send the image straight to the printer.

## Latest Release
Download the latest release (https://github.com/brhinescot/Cropper/releases)
