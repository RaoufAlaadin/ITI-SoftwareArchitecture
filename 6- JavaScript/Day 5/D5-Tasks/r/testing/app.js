var childWindow, x, y, direction, childWidth=500, childHeight=500, childHeightOffset=38;
var width=window.innerWidth, height=window.innerHeight, slope, intervalID;
var message, index, before;

function moving() {

    if (!!!intervalID)
    {
        x = y  = direction = 0;

        childWindow = window.open("./empty.html", "_blank", `fullscreen=0,height=${childHeight},width=${childWidth},top=${y},left=${x}`);
        
        intervalID = setInterval(function diagonal() {
    
            if (childWindow.closed) {
                stop();
            }

            width = window.innerWidth;
            height = window.innerHeight;
    
            childHeight = childWindow.innerHeight;
            childWidth = childWindow.innerWidth;
    
            slope = (height-childHeight+childHeightOffset)/(width-childWidth);
    
            if (direction == 0) {
                childWindow.moveTo(x+=5, y=slope*x);
                if (x+childWidth >= width) {
                    direction = 1;
                }
            } else {
                childWindow.moveTo(x-=5, y=slope*x);
                if (x <= 0) {
                    direction = 0;
                }
            }
    
        }, 50);
    }

};

function writing() {
    
    if (!!!intervalID)
    {
        childWindow = window.open("./empty.html", "_blank", `fullscreen=0,height=${childHeight},width=${childWidth},top=${height/2},left=${width/2}`);
        message = "Lorem ipsum dolor sit amet consectetur adipisicing elit...";
        index = 0;

        intervalID = setInterval(function letterByLetter() {

            if (!childWindow.closed && index < message.length) {
                childWindow.document.write(message[index++]);
            } else {
                stop();
            }

        }, 50);
    }
};

function scrolling() {

    if (!!!intervalID)
    {
        childWindow = window.open("./empty.html", "_blank", `fullscreen=0,height=${childHeight},width=${childWidth},top=${height/2},left=${width/2}`);
        
        message = `Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sit amet mauris commodo quis imperdiet massa tincidunt. Velit scelerisque in dictum non consectetur. Sollicitudin nibh sit amet commodo nulla facilisi nullam vehicula. Duis tristique sollicitudin nibh sit. Pulvinar proin gravida hendrerit lectus. Id neque aliquam vestibulum morbi blandit cursus risus at. At volutpat diam ut venenatis. Mattis pellentesque id nibh tortor id. Donec et odio pellentesque diam volutpat. Risus ultricies tristique nulla aliquet enim tortor at auctor urna. Eu augue ut lectus arcu. Consectetur lorem donec massa sapien faucibus et molestie ac.
        Velit sed ullamcorper morbi tincidunt ornare massa. Non curabitur gravida arcu ac tortor dignissim convallis aenean. Nisl nisi scelerisque eu ultrices vitae. Euismod lacinia at quis risus sed vulputate odio ut. Vitae aliquet nec ullamcorper sit. Condimentum id venenatis a condimentum vitae sapien. Diam phasellus vestibulum lorem sed risus ultricies. In dictum non consectetur a. Tellus molestie nunc non blandit. Faucibus turpis in eu mi bibendum neque. At erat pellentesque adipiscing commodo. Duis tristique sollicitudin nibh sit amet commodo nulla facilisi. Quis lectus nulla at volutpat diam ut. Odio pellentesque diam volutpat commodo sed egestas egestas fringilla. Netus et malesuada fames ac turpis egestas maecenas. Dui id ornare arcu odio ut sem nulla. Sed augue lacus viverra vitae congue eu consequat ac. Tristique sollicitudin nibh sit amet commodo nulla facilisi.
        
        Habitant morbi tristique senectus et. Accumsan in nisl nisi scelerisque. Pharetra diam sit amet nisl suscipit adipiscing bibendum est ultricies. Tortor aliquam nulla facilisi cras. Risus feugiat in ante metus dictum at tempor commodo. Morbi tincidunt augue interdum velit euismod in pellentesque massa. Vel risus commodo viverra maecenas accumsan lacus. Aliquet sagittis id consectetur purus ut. Aenean euismod elementum nisi quis eleifend quam adipiscing vitae proin. Eu ultrices vitae auctor eu augue ut. In hendrerit gravida rutrum quisque non tellus orci ac. Iaculis at erat pellentesque adipiscing commodo elit at. Vitae ultricies leo integer malesuada nunc vel risus commodo. Aenean euismod elementum nisi quis eleifend quam adipiscing vitae. Lacus suspendisse faucibus interdum posuere lorem ipsum dolor. Porttitor lacus luctus accumsan tortor posuere ac ut. Pharetra convallis posuere morbi leo urna. Quis hendrerit dolor magna eget est lorem ipsum. Ut aliquam purus sit amet luctus venenatis lectus.
        
        Libero volutpat sed cras ornare arcu dui vivamus arcu felis. Ut faucibus pulvinar elementum integer enim neque. Consequat nisl vel pretium lectus. Urna nunc id cursus metus aliquam eleifend mi. Sodales ut etiam sit amet nisl. Tristique nulla aliquet enim tortor at auctor urna nunc. Risus pretium quam vulputate dignissim suspendisse in est ante. In est ante in nibh mauris cursus mattis molestie a. Massa enim nec dui nunc. Duis ultricies lacus sed turpis tincidunt id aliquet.
        
        Amet risus nullam eget felis eget nunc lobortis mattis aliquam. Mauris a diam maecenas sed enim ut sem viverra aliquet. Ac placerat vestibulum lectus mauris ultrices eros in cursus. Ipsum consequat nisl vel pretium lectus quam. Cras sed felis eget velit aliquet sagittis id consectetur. Erat pellentesque adipiscing commodo elit at. Sed felis eget velit aliquet sagittis id consectetur purus ut. Sed enim ut sem viverra aliquet eget sit amet. Tortor condimentum lacinia quis vel eros donec ac odio tempor. Viverra vitae congue eu consequat ac felis donec et odio. Ullamcorper velit sed ullamcorper morbi tincidunt ornare massa. Aenean et tortor at risus viverra adipiscing at. Aliquam malesuada bibendum arcu vitae. Lacinia quis vel eros donec ac odio tempor.`;
        
        childWindow.document.write(message);
        index = 0;
        before = -1;

        intervalID = setInterval(function scrollableAdd() {
            if (!childWindow.closed && before != childWindow.scrollY) {
                before = childWindow.scrollY;
                childWindow.scrollTo(0, index+=10);
            } else {
                stop();
            }

        }, 100);
    }
}

function stop() {
    if (!childWindow.closed) {
        childWindow.close();
    }

    clearInterval(intervalID);
    intervalID = null;
}