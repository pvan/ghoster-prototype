# ghoster

ghoster is a borderless, resizable, dockable youtube video player that supports window transparency and click transparency ("ghost mode"), always-on-top functionality and command line launch options.

This version is a prototype in C# using wpf and it's sort of a hacked-together mess.

It uses an WebBrowser control to embed the youtube videos which means videos with restricted playback options won't load. Also I couldn't get the youtube api to work becasue I think (going from memory here), the WebBrowser control didn't support postMessage or something (it was equivalent to an older version of IE I think). Hence it can't tell how much of the video has played or a number of other useful things.

---

Still, for a prototype, it sort of works.

For a menu, right-click on the video or the taskbar icon. (If ghost mode is enabled, only the taskbar icon menu will work since the video will ignore all clicks). 

To load a video, drag a selected url from the chrome address bar into the window (similar to creating a shortcut from url dragging). Or copy the url to the clipboard and paste it using the right-click menu or just ctrl+v while the window is selected.

The built-in youtube video controls (volume, tracking) should all work, and click anywhere else on the video to drag the window around. Resize by dragging the edges. And you should be able to dock it to the edge of the screen, though I haven't seen what happens with multiple monitors yet. Double-click to full-screen.

You can also toggle ghost mode by clicking the taskbar icon (the icon will change).

---

Command line launch options:

    -oX               set opacity to X (0-100)
    -wX               set width to X (in pixels)
    -hX               set height to X (in pixels)
    -top  -t  -aot    enable always-on-top
    -ghost  -gm       enable ghost mode (can't be clicked)
    -novid  -blank    don't load a video on launch
    -colors -panels   show debug panels
    -errors -js       allow js errors to appear
    -debug            show panels and allow errors
    -help             display help text
    
    pass a url as any argument to start on that video, may need to wrap the url in double quotes

---

The idea is to eventually support any video files, vimeo, etc. See https://github.com/pvan/ghoster for an update of this project.

Some alternatives:
- "floating for youtube" chome extension might be worth looking into
- vlc has a borderless mode and works with youtube videos but you can't move or resize while in borderless mode


