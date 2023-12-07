@Code
    ViewData("Title") = "About"
End Code

<div class="wl-content">
    <h2 style="color:black">
        Search
    </h2>
</div>

<div class="wl-search">
    <input type="text" placeholder="Enter any keyword" name="searchKey" class="wl-input" />
    <div class="wl-searchicon">
        <button type="button" class="search-btn">
            <img src="~/Images/searchicon.png" />
        </button>
    </div>
</div>
<br />
<div class="row product-container">
    <div class="col-md-3 col-sm-3 col-xs-6" style="margin-bottom:8px">
        <div class="thumbnail product-item" style="height:300px">
            <img class="img-responsive" title="Click to view" style="cursor:pointer;max-height:60%;width:100%" src="~/Images/cake.jpg" />

            <div class="caption">
                <h5>Cake design</h5>
                <h6>by CakeDesigner</h6>
                <div class="product-item-price">
                    <p>100$</p>
                </div>
            </div>
        </div>
    </div>
</div>