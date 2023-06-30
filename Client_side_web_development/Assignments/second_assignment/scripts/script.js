// This is the script file for the index.html file
// Author: Ujjwal Poudel
// Last edited: 2023/06/17
// This file creates the slideshow for the index.html file

window.addEventListener("load", createDisplay());

// Creating a function to display
function createDisplay() {
    //Creating global variables
    // Image files in array
    let images = [
        "assets/images/heritagesite.jpg",
        "assets/images/arts.jpg", 
        "assets/images/dance.jpg", 
        "assets/images/bungyjump.jpg", 
        "assets/images/lake.jpg", 
        "assets/images/valley.jpg",
        "assets/images/forest.jpg", 
        "assets/images/gumba.jpg", 
        "assets/images/Lakes-Of-Nepal.webp", 
        "assets/images/mountain.jpg", 
        "assets/images/Paragliding.jpg", 
        "assets/images/raftingNepal.jpeg",
        "assets/images/Rock-Climbing.jpg", 
        "assets/images/templeNepal.jpg"];

    // Image caption in array
    let imageCaption = new Array();
    imageCaption[0] = "Soyambunath Temple in Nepal";
    imageCaption[1] = "Nepali Culutral Arts";
    imageCaption[2] = "Nepali Cultural Dance";
    imageCaption[3] = "Bungy Jumping Experience in Nepal";
    imageCaption[4] = "Fewa Lake in Pokhara, Nepal";
    imageCaption[5] = "Arun Valley View, Nepal";
    imageCaption[6] = "Tropical Forest in Nepal";
    imageCaption[7] = "View of Gumba in Nepal";
    imageCaption[8] = "Lakes of Nepal";
    imageCaption[9] = "Mountains in Nepal";
    imageCaption[10] = "Paragliding in Nepal";
    imageCaption[11] = "Rafting in Nepal";
    imageCaption[12] = "Rock Climbing in Nepal";
    imageCaption[13] = "Temple in Nepal";

    let music = new Audio("./assets/audio/Nepali-music.mp3");

    // creating an array to store the favourites images
    let favImages = [];
    // create a variable to store the main display
    let display = document.getElementById("main__slides");

    // creating the parts of the display
    let displayCounter = document.createElement("div");
    let displayImage = document.createElement("div");
    let displayPlay = document.createElement("div");
    let displayPrevious = document.createElement("div");
    let displayNext = document.createElement("div");
    let image = document.createElement("img");
    let body__buttons = document.createElement("div");

    // Creating main display classes
    let body__top = document.createElement("div");
    body__top.setAttribute("id", "body__top");
    display.appendChild(body__top);

    let body__fav = document.createElement("div");
    let displayFavorite = document.createElement("div");

    let body__bottom = document.createElement("div");
    body__bottom.setAttribute("id", "body__bottom");
    display.appendChild(body__bottom);

    // Creating the favourite wrapper
    let favWrapper = document.createElement("div");
    favWrapper.setAttribute("id", "fav__wrapper");
    display.appendChild(favWrapper);

    // Image counter
    let imageCount = images.length;
    let currentImage;

    // getting the main display
    body__one();
    body__slides();
    body__button();

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
        image.addEventListener("click", overlayImage);
        displayImage.appendChild(image);
        // console.log(images[i]);
        document.addEventListener('keydown', function (event) {
            if (event.key === "ArrowRight") {
                nextSlide();
            }
            else if (event.key === "ArrowLeft") {
                previousSlide();
            }
            else if (event.code === "Space") {
                toggleSlide();
            }
        });
    }

    // creating a function to display the play, previous and next buttons
    function body__button() {
        body__buttons.setAttribute("id", "body__buttons");
        body__bottom.appendChild(body__buttons);

        // designing the displayPlay
        body__buttons.appendChild(displayPlay);
        displayPlay.setAttribute("id", "main__slides__svg");
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
        displayPrevious.setAttribute("id", "main__slides__svg");
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
        displayNext.setAttribute("id", "main__slides__svg");
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
            // Pausing music
            music.pause();
            interval = undefined;
        } else {
            nextSlide();
            // Playing music
            music.play();
            interval = window.setInterval(nextSlide, 2000);
        }
    }

    // Creating a function to display and add images to favourites
    function addFavorite() {
        favWrapper.setAttribute("style", "display: flex;");
        // // Checking the length of the favorite images
        if (favImages.length < 5) {

            // checking if the image is already in the favorites
            if (favImages.includes(images[currentImage - 1])) {
                //         // A small alert to notify the user that the image is already in the favourites
                window.alert("This image is already in the favourites");
            }

            // If the image is not in the favourites, then add it to the favourites
            else {
                let favImage = document.createElement("img");
                favImage.setAttribute("class", "fav__image");
                favWrapper.appendChild(favImage);
                favImage.setAttribute("src", images[currentImage - 1]);
                favImages.push(images[currentImage - 1]);
                favImage.addEventListener("click", removeFavorite);
            }
        }
    }

    // Creating a function to remove images from favorites
    function removeFavorite() {
        let favImage = document.getElementsByClassName("fav__image");
        if (favImage.length > 0) {
            // Remove the last favorite image
            let lastImage = favImage[favImage.length - 1];
            lastImage.remove();
            favImages.pop(favImages.length - 1);
        }

        // If there are no images in the favorites, then hide the favorites
        if (favImage.length == 0) {
            favWrapper.setAttribute("style", "display: none;");
        }
    }

    // creating a function to overlay the image
    function overlayImage() {
        let bodyOverlay = document.createElement("body__overlay");
        bodyOverlay.setAttribute("id", "body__overlay");

        let overlay = document.createElement("div");
        overlay.setAttribute("id", "overlay");
        bodyOverlay.appendChild(overlay);

        // Adding figure to the overlay
        let figure = document.createElement("figure");
        figure.setAttribute("id", "figure");
        overlay.appendChild(figure);

        // Adding image to the figure
        let overlayImage = this.cloneNode(true);
        overlayImage.setAttribute("id", "overlay__image");
        figure.appendChild(overlayImage);

        // Adding caption to the figure
        let caption = document.createElement("figcaption");
        caption.setAttribute("id", "caption");
        caption.textContent = imageCaption[currentImage - 1];
        figure.appendChild(caption);

        // Adding div to store favorites and close button
        let overLayOptions = document.createElement("div");
        overLayOptions.setAttribute("id", "overlay__options");
        overlay.appendChild(overLayOptions);

        // Adding favorites button
        let favButton = document.createElement("div");
        favButton.setAttribute("id", "fav__button");
        overLayOptions.appendChild(favButton);
        favButton.addEventListener("click", addFavorite);

        let xhr6 = new XMLHttpRequest();
        xhr6.open("GET", "./assets/svg/heart-outline.svg", true);
        xhr6.onreadystatechange = function () {
            if (xhr6.readyState === 4 && xhr6.status === 200) {
                var svgString = xhr6.responseText;
                favButton.innerHTML = svgString;
            }
        };
        xhr6.send();

        // Adding overlay close button
        let closeButton = document.createElement("div");
        closeButton.setAttribute("id", "close__button");
        overLayOptions.appendChild(closeButton);

        let xhr5 = new XMLHttpRequest();
        xhr5.open("GET", "./assets/svg/exit-overlay.svg", true);
        xhr5.onreadystatechange = function () {
            if (xhr5.readyState === 4 && xhr5.status === 200) {
                var svgString = xhr5.responseText;
                closeButton.innerHTML = svgString;
            }
        };
        xhr5.send();

        closeButton.addEventListener("click", function () {
            document.body.removeChild(bodyOverlay);
        });
        document.body.appendChild(bodyOverlay);
        document.addEventListener('keydown', function (event) {
            if (event.key === "Escape") {
                document.body.removeChild(bodyOverlay);
            }
        });
    }
}