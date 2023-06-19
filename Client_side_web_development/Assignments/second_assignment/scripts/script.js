// This is the script file for the index.html file
// Author: Ujjwal Poudel
// Last edited: 2023/06/17
// This file creates the slideshow for the index.html file


window.addEventListener("load", createDisplay());

// Creating a function to display
function createDisplay() {
    //Creating global variables

    // create a variable to store the main display
    let display = document.getElementById("main__slides");


    // Image files in array
    let images = ["assets/images/heritagesite.jpg", "assets/images/bungyjump.jpg", "assets/images/forest.jpg", "assets/images/gumba.jpg",
        "assets/images/Lakes-Of-Nepal.webp", "assets/images/mountain.jpg", "assets/images/Paragliding.jpg", "assets/images/raftingNepal.jpeg",
        "assets/images/Rock-Climbing.jpg", "assets/images/templeNepal.jpg"];

    // Image caption in array
    let imageCaption = new Array();
    imageCaption[0] = "Heritage site of Nepal";
    imageCaption[1] = "bungy jump scene in Nepal";
    imageCaption[2] = "Tropical forest of Nepal";
    imageCaption[3] = "Gumba in Nepal";
    imageCaption[4] = "Lakes of Nepal";
    imageCaption[5] = "Mountain of Nepal";
    imageCaption[6] = "Paragliding in Nepal";
    imageCaption[7] = "Rafting in Nepal";
    imageCaption[8] = "Rock climbing in Nepal";
    imageCaption[9] = "Temple of Nepal";

    // creating the parts of the display
    let displayCounter = document.createElement("div");
    let displayFavorite = document.createElement("div");
    let displayImage = document.createElement("div");
    let displayPlay = document.createElement("div");
    let displayPrevious = document.createElement("div");
    let displayNext = document.createElement("div");
    let image = document.createElement("img");
    let body__fav = document.createElement("div");
    let body__buttons = document.createElement("div");

    // Creating main display classes
    let body__top = document.createElement("div");
    body__top.setAttribute("id", "body__top");
    display.appendChild(body__top);

    let body__bottom = document.createElement("div");
    body__bottom.setAttribute("id", "body__bottom");
    display.appendChild(body__bottom);

    // Image counter
    let imageCount = images.length;
    let currentImage;

    // getting the main display
    body__one();
    body__slides();
    body__buttons();

    // Creating a function to generate parts for counter and favourite
    function body__one() {
        currentImage = 1;
        body__fav.setAttribute("id", "body__fav");
        body__fav.addEventListener("click", addFavorite);
        body__top.appendChild(body__fav);
        
        // designing the displayCounter
        body__fav.appendChild(displayCounter);
        displayCounter.setAttribute("id", "main__slides__counter");
        displayCounter.textContent = currentImage + "/" + imageCount;

        // designing the displayFavorite
        body__fav.appendChild(displayFavorite);
        displayFavorite.setAttribute("id", "main__slides__favorite");
        // XMLHttpRequest object allows us to make HTTP requests to fetch the svg file contents
        let xhr1 = new XMLHttpRequest();

        // Opens a GET request to the specified SVG file path
        // The "true" parameter makes the request asynchronous
        xhr1.open("GET", "./assets/svg/heart-outline.svg", true);
        // Setting up an event handler to be triggered whenever the state of the request changes
        xhr1.onreadystatechange = function () {
            // Checks if the request has completed successfully (readyState 4) and the status is 200 (HTTP OK)
            if (xhr1.readyState === 4 && xhr1.status === 200) {
                // Store the response text, which is the content of the SVG file, in a variable
                var svgString = xhr1.responseText;

                // Set the innerHTML property of the displayFavorite div to the SVG string
                // This will display the SVG content within the div
                displayFavorite.innerHTML = svgString;
            }
        };
        xhr1.send();
    }


    //creating a function to display the image slide show
    function body__slides() {
        body__top.appendChild(displayImage);
        displayImage.setAttribute("id", "main__slides__image");
        let i = 0;
        image.setAttribute("src", images[i]);
        image.setAttribute("alt", imageCaption[i]);
        displayImage.appendChild(image);
        // console.log(images[i]);
    }

    // creating a function to display the play, previous and next buttons
    function body__buttons() {
        body__buttons.setAttribute("id", "body__buttons");
        body__bottom.appendChild(body__buttons);

        // designing the displayPlay
        body__buttons.appendChild(displayPlay);
        displayPlay.setAttribute("id", "main__slides__play");
        let xhr2 = new XMLHttpRequest();
        xhr2.open("GET", "./assets/svg/play-pause-bold.svg", true);
        xhr2.onreadystatechange = function () {
            if (xhr2.readyState === 4 && xhr2.status === 200) {
                var svgString = xhr2.responseText;
                displayPlay.innerHTML = svgString;
            }
        };
        xhr2.send();
        displayPlay.addEventListener("click", toggleSlide);

        // designing the displayPrevious
        body__buttons.appendChild(displayPrevious);
        displayPrevious.setAttribute("id", "main__slides__previous");
        let xhr3 = new XMLHttpRequest();
        xhr3.open("GET", "./assets/svg/previous.svg", true);
        xhr3.onreadystatechange = function () {
            if (xhr3.readyState === 4 && xhr3.status === 200) {
                var svgString = xhr3.responseText;
                displayPrevious.innerHTML = svgString;
            }
        };
        xhr3.send();
        displayPrevious.addEventListener("click", previousSlide);

        // designing the displayNext
        body__buttons.appendChild(displayNext);
        displayNext.setAttribute("id", "main__slides__next");
        let xhr4 = new XMLHttpRequest();
        xhr4.open("GET", "./assets/svg/next.svg", true);
        xhr4.onreadystatechange = function () {
            if (xhr4.readyState === 4 && xhr4.status === 200) {
                var svgString = xhr4.responseText;
                displayNext.innerHTML = svgString;
            }
        }
        xhr4.send();
        displayNext.addEventListener("click", nextSlide);
    }

    // creating a function to show next slides in slide show
    function nextSlide() {
        // displayImage.appendChild(displayImage.firstElementChild);
        if (currentImage < imageCount) {
            currentImage++;
            displayCounter.textContent = currentImage + "/" + imageCount;
        }
        else {
            currentImage = 1;
        }

        displayCounter.textContent = currentImage + "/" + imageCount;
        image.setAttribute("src", images[currentImage - 1]);
    }

    // creating a function to show previous slides in slide show
    function previousSlide() {
        if (currentImage > 1) {
            currentImage--;
            displayCounter.textContent = currentImage + "/" + imageCount;
            image.setAttribute("src", images[currentImage - 1]);
        }


        else {
            currentImage = imageCount;
            displayCounter.textContent = currentImage + "/" + imageCount;
            image.setAttribute("src", images[currentImage - 1]);
        }


    }

    // declaring a variable to store the interval
    let interval;
    // creating a function to play the slideshow
    function toggleSlide() {
        if (interval) {
            window.clearInterval(interval);
            interval = undefined;
        } else {
            nextSlide();
            interval = window.setInterval(nextSlide, 1500);
        }
    }

    // creating a function to add the favorite image
    let favCount = 0;
    function addFavorite() {
        if (favCount < 5 && favCount == 0) {
            let fav__wrapper = document.createElement("div");
            fav__wrapper.setAttribute("id", "fav__wrapper");
            display.appendChild(fav__wrapper);
            favLoop();
            favCount++;
        }
        else if (favCount < 5) {
            favLoop();
            favCount++;
        }
    }
    function favLoop() {
        console.log("favLoop");

        let fav__image = document.createElement("img");
        fav__image.setAttribute("id", "fav__image");
        fav__wrapper.appendChild(fav__image);
        fav__image.setAttribute("src", images[currentImage - 1]);
    }
}