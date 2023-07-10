

window.addEventListener("load", function () {

  // Getting all the required elements
  var sameAsBillingCheckbox = document.getElementById("same_as_billing");
  var billingFields = [
    document.getElementById("f_name"),
    document.getElementById("l_name"),
    document.getElementById("address"),
    document.getElementById("city"),
    document.getElementById("state"),
    document.getElementById("zip"),
    document.getElementById("phone"),
  ];
  var deliveryFields = [
    document.getElementById("f_name_delivery"),
    document.getElementById("l_name_delivery"),
    document.getElementById("address_delivery"),
    document.getElementById("city_delivery"),
    document.getElementById("state_delivery"),
    document.getElementById("zip_delivery"),
    document.getElementById("phone_delivery"),
  ];

  var stateDropdown = document.getElementById("state");
  // Selecting the default state value
  stateDropdown.selectedIndex = -1;

  var zipCode = billingFields[5];
  // Setting the pattern attribute for zip code field of 6 digits with alphanumeric characters
  // zipCode.setAttribute("pattern", "[0-9a-zA-Z]{6}");
  // 

  sameAsBillingCheckbox.addEventListener("change", function () {
    if (sameAsBillingCheckbox.checked) {
      copyFieldValues(billingFields, deliveryFields);
    } else {
      clearFieldValues(deliveryFields);
    }
  });

  // Function to copy field values
  function copyFieldValues(sourceFields, targetFields) {
    for (var i = 0; i < sourceFields.length; i++) {
      targetFields[i].value = sourceFields[i].value;
    }
  }

  // Function to clear field values
  function clearFieldValues(fields) {
    for (var i = 0; i < fields.length; i++) {
      fields[i].value = "";
    }
  }

  // Validating empty fields
  function validateEmptyFields(fields) {
    for (var i = 0; i < fields.length; i++) {
      if (fields[i].value.trim() === "") { // Trim method removes whitespace from both ends of a string
        fields[i].setCustomValidity("Please fill out this section");
        fields[i].classList.add("invalid");
      } else {
        fields[i].setCustomValidity("");
        fields[i].classList.remove("invalid");
        // classList property returns the class name(s) of an element, as a DOMTokenList object
      }
    }
  }

  // Adding event listeners for input and change events
  billingFields.forEach(function (field) {
    field.addEventListener("input", function () {
      validateEmptyFields(billingFields);
    });
  });

  deliveryFields.forEach(function (field) {
    field.addEventListener("input", function () {
      validateEmptyFields(deliveryFields);
    });
  });
});
