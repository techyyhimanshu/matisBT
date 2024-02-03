// External JavaScript file

function updateSessionCountdown() {
    var timeoutSeconds = sessionTimeoutSeconds;

    var intervalId = setInterval(function () {
        var minutes = Math.floor(timeoutSeconds / 60);
        var seconds = timeoutSeconds % 60;

        var sessionCountdownElement = document.getElementById('<%= sessionCountdown.ClientID %>');

        if (sessionCountdownElement) {
            sessionCountdownElement.innerHTML = minutes + 'm ' + seconds + 's';
        }

        timeoutSeconds--;

        if (timeoutSeconds < 0) {
            // Display an error message
            if (sessionCountdownElement) {
                sessionCountdownElement.innerHTML = 'Session Expired';
            }

            // Redirect to the login page after a delay (e.g., 3 seconds)
            setTimeout(function () {
                window.location.href = 'Login.aspx'; // Redirect to your login page
            }, 3000);

            // Clear the interval to stop updating the timer
            clearInterval(intervalId);
        }
    }, 1000);
}

window.onload = updateSessionCountdown;
