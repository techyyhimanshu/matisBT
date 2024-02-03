document.addEventListener('DOMContentLoaded', function () {
    setInterval(createSnowflake, 500); // Create a new snowflake every 1000 milliseconds (1 second)
    //setInterval(createGift, 10000); // Create a new snowflake every 1000 milliseconds (1 second)
});

function createSnowflake() {
    var snowflake = document.createElement('div');
    snowflake.className = 'snowflake';
    snowflake.style.left = Math.random() * 100 + 'vw';
    snowflake.style.animationDuration = 5 + Math.random() * 10 + 's'; // Adjusted for more regular fall
    snowflake.style.width = (Math.random() * 1 + 15) + 'px';
    snowflake.style.height = (Math.random() * 1 + 15) + 'px';


    document.body.appendChild(snowflake);

    // Remove the snowflake after animation completes
    snowflake.addEventListener('animationiteration', function () {
        snowflake.remove();
    });
}

function createGift() {
    var snowflake = document.createElement('div');
    snowflake.className = 'snowGift';
    snowflake.style.left = Math.random() * 100 + 'vw';
    snowflake.style.animationDuration = 5 + Math.random() * 10 + 's'; // Adjusted for more regular fall


    document.body.appendChild(snowflake);

    // Remove the snowflake after animation completes
    snowflake.addEventListener('animationiteration', function () {
        snowflake.remove();
    });
}