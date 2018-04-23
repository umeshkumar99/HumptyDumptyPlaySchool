function fillDropdown(ddID, url, dataval) {
   // debugger;
    //alert(ddID.id.toString());
    $.ajax({
        type: 'Post',
        url: url,
        dataType: 'json',
        data: { id: dataval },
        success: function (state) {
          //  debugger;
            // alert('sucess');
            $.each(state, function (index, state) {
               // alert(this.Value.toString() + this.Text.toString());
                ddID.append('<option value="' + this.Value.toString() + '">' + this.Text.toString() + '</option>');
            });
        },

        error: function (ex) {
            alert(ex.statusText.toString());
        }

    });
}

function readURL(input, target) {
    //        debugger;
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            target.attr('src', e.target.result).css('display', 'block');
            //$('#blah').attr('src', e.target.result).css('display','block');
        }
        reader.readAsDataURL(input.files[0]);
    }
}