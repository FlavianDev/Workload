@Code
    ViewData("Title") = "Home Page"
End Code

<div class="jumbotron">
    <h1>What is Workload?</h1>
    <p class="lead">
        Workload is a platform for freelancers to advertise and sell their services and for people to find passionate people for their work.
    </p><br />
    <div class="row">
        <div class="col-md-4">
            <h2>Easy to use</h2>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit,
                sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi
                ut aliquip ex ea commodo consequat.
            </p>
            @*<p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301865">Learn more &raquo;</a></p>*@
        </div>
        <div class="col-md-4">
            <h2>Make money from your hobby</h2>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit,
                sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi
                ut aliquip ex ea commodo consequat.
                Duis aute irure dolor in reprehenderit
                in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
            </p>
        </div>
        <div class="col-md-4">
            <h2>Find the best service</h2>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit,
                sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi
                ut aliquip ex ea commodo consequat.
            </p>
        </div>
    </div>
</div>


<div class="wl-content">
    <h2 style="color:black">
        Search
    </h2>
</div>

<div class="wl-search">
    <input type="text" placeholder="Enter any keyword" name="searchKey" class="wl-input"/>
    <div class="wl-searchicon">
        <button type="button" class="search-btn">
            <img src="~/Images/searchicon.png"/>
        </button>
    </div>
</div>

<div class="page-header">
    <h2>
        Popular
    </h2>
</div>
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
    <div class="col-md-3 col-sm-3 col-xs-6" style="margin-bottom:8px">
        <div class="thumbnail product-item" style="height:300px">
            <img class="img-responsive" title="Click to view" style="cursor:pointer;max-height:60%;width:100%" src="~/Images/phones.jfif" />

            <div class="caption">
                <h5>Mobile Repair (Android, IOS)</h5>
                <h6>by MikesRepairs</h6>
                <div class="product-item-price">
                    <p>220$</p>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-3 col-sm-3 col-xs-6" style="margin-bottom:8px">
        <div class="thumbnail product-item" style="height:300px">
            <img class="img-responsive" title="Click to view" style="cursor:pointer;max-height:60%;width:100%" src="~/Images/gift.jfif" />

            <div class="caption">
                <h5>Custom Gift Boxes</h5>
                <h6>by Isabella</h6>
                <div class="product-item-price">
                    <p>30$</p>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-3 col-sm-3 col-xs-6" style="margin-bottom:8px">
        <div class="thumbnail product-item" style="height:300px">
            <img class="img-responsive" title="Click to view" style="cursor:pointer;max-height:60%;width:100%" src="~/Images/web.jfif" />

            <div class="caption">
                <h5>Professional Web Design</h5>
                <h6>by MarcusWebsites</h6>
                <div class="product-item-price">
                    <p>from 80$</p>
                </div>
            </div>
        </div>
    </div>
</div>