function dropGift() {
    console.log("running");
    // Array of possible gift images
    var giftImages = ["../Images/Present1.png", "../Images/Present2.png", "../Images/Present3.png", "../Images/Present4.png", "../Images/Present5.png", "../Images/Present6.gif"];

    // Randomly select a gift image from the array
    var randomGiftImage = giftImages[Math.floor(Math.random() * giftImages.length)];

    // Create a new image element for the falling gift
    var giftImage = document.createElement("img");
    giftImage.src = randomGiftImage;
    giftImage.alt = "Falling Gift";
    giftImage.classList.add("falling-gift");

    giftImage.style.width = "35px";
    //giftImage.style.height = "35px";
    giftImage.style.zIndex = "10000";

    // Set the initial position below the clicked image
    var padoruImage = document.getElementById("padoruImage");
    var rect = padoruImage.getBoundingClientRect();
    giftImage.style.left = rect.left + "px";
    giftImage.style.top = rect.bottom + "px"; // Set top position below the clicked image

    // Append the gift image to the body
    document.body.appendChild(giftImage);

    // Remove the gift image after the animation completes
    giftImage.addEventListener("animationend", function () {
        document.body.removeChild(giftImage);
    });
}