# ghoster

ghoster is a borderless, resizable, dockable youtube video player that supports window transparency and click transparency ("ghost mode"), always-on-top functionality and command line launch options.

Don't get the wrong idea, it's a hacked-together mess.

It uses an iframe to embed the youtube videos which means videos with restricted playback options don't work yet. Also I couldn't figure out a way to call the youtube api, so it can't tell how much of the video has played or a number of other useful things.

---

Still, it sort of works.

Right-click on the video or the taskbar icon for a menu. (If ghost mode is enabled, only the taskbar icon menu will work since the video will ignore all clicks). 

You can drag a selected url from the chrome address bar into the window to load a new video (similar to creating a shortcut from url dragging). Or copy the url to the clipboard and paste it using the right-click menu or just ctrl+v (if the ghoster window is selected when pasting).

The built-in youtube video controls (volume, tracking) should all work, and left-click anywhere else on the video to drag the window around. Resize by dragging the edges. And you should be able to dock it to the edge of the screen, though I haven't seen what happens with multiple monitors yet. Double-click to full-screen.

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

The idea was to eventually support any video files, vimeo, etc, but I think it might be worth going back to the drawing board on this one.

Some alternatives maybe worth looking into:
- "floating for youtube" chome extension
- vlc with borderless mode


