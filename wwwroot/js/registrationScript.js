document.addEventListener('DOMContentLoaded', function () {
    // Get all plan selection buttons
    const planButtons = document.querySelectorAll('.pricing-card button');

    // Get form elements
    const registrationForm = document.getElementById('registrationForm');
    const planInput = document.getElementById('Plan');
    const planInfoAlert = document.getElementById('planInfo');
    const submitButton = document.getElementById('submitButton');

    // Function to check if form is ready to submit
    function checkFormReadiness() {
        if (planInput.value) {
            planInfoAlert.innerHTML = `<strong>Selected Plan:</strong> ${planInput.value} Plan`;
            planInfoAlert.classList.remove('alert-info');
            planInfoAlert.classList.add('alert-success');
            submitButton.disabled = false;
        } else {
            planInfoAlert.innerHTML = 'Please select a plan before submitting';
            planInfoAlert.classList.remove('alert-success');
            planInfoAlert.classList.add('alert-info');
            submitButton.disabled = true;
        }
    }

    // Add click event listeners to all plan buttons
    planButtons.forEach(button => {
        button.addEventListener('click', function () {
            // Get the plan name from the data attribute
            const planName = this.getAttribute('data-plan');

            // Reset all buttons to their original state
            planButtons.forEach(btn => {
                btn.classList.remove('btn-success');
                btn.classList.remove('btn-primary');
                btn.classList.add('btn-outline-primary');
                btn.textContent = 'Select Plan';
            });

            // Update the clicked button to show it's selected
            this.classList.remove('btn-outline-primary');
            this.classList.add('btn-success');
            this.textContent = 'Selected';

            // Update the hidden input with selected plan
            planInput.value = planName;

            // Update form readiness
            checkFormReadiness();

            // Scroll to the form
            document.getElementById('registration-form').scrollIntoView({ behavior: 'smooth' });
        });
    });

    // Form validation before submission
    registrationForm.addEventListener('submit', function (event) {
        if (!planInput.value) {
            event.preventDefault();
            alert('Please select a plan before submitting your registration.');
            document.querySelector('.program-plans').scrollIntoView({ behavior: 'smooth' });
            return false;
        }

        // Additional form validation can be added here if needed

        // Form will be submitted normally to your controller
        return true;
    });

    document.addEventListener('DOMContentLoaded', function () {
        const form = document.getElementById('registrationForm');

        if (document.getElementById('successMessage')) {
            form.reset(); // Clear form when success message is shown
        }
    });


    // Initial check
    checkFormReadiness();
});