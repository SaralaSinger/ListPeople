﻿$(() => {
    $("#add-rows").on('click', function () {
        AddRows();
        num++;
    });
    let num = 1;
    function AddRows() {
        $("#ppl-rows").append(`<div class='row person-row' style='margin-bottom: 10px;'> 
            <div class='col-md-4'> 
                <input class='form-control' type='text' name='people[${num}].firstname' placeholder='First Name' /> 
           </div> 
            <div class='col-md-4'>   
                <input class='form-control' type='text' name='people[${num}].lastname' placeholder='Last Name' /> 
            </div> 
            <div class='col-md-4'> 
                <input class='form-control' type='text' name='people[${num}].age' placeholder='Age' /> 
           </div> 
        </div>`)
    }

})