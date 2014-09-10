(function() {

    CanvasRenderingContext2D.prototype.fillRoundRect = function(x, y, dx, dy, radius, style) {

        if (typeof style != "undefined") {
            this.fillStyle = style;
        }

        this.beginPath();

        this.moveTo(x + radius, y);
        this.lineTo(x + dx - 2 * radius, y);
        this.arcTo(x + dx, y, x + dx, y + radius, radius);
        this.lineTo(x + dx, y + dy - radius);
        this.arcTo(x + dx, y + dy, x + dx - radius, y + dy, radius);
        this.lineTo(x + radius, y + dy);
        this.arcTo(x, y + dy, x, y + dy - radius, radius);
        this.lineTo(x, y + radius);
        this.arcTo(x, y, x + radius, y, radius);

        this.fill();
    };

    var createCanvas = function(parentSelector, width, height) {

        var parent = $(parentSelector);

        var canvas = $("<canvas></canvas>");

        canvas.attr("width", width);
        if (typeof height == "undefined") {
            height = width;
        }
        canvas.attr("height", height);

        parent.append(canvas);

        var context = canvas[0].getContext("2d");

        context.translate(0.5, 0.5);

        return context;
    }

    var colors = {
        background: "#e9e9e9",
        red: "#c41e3a",
        green: "#009e60",
        blue: "#0051ba",
        orange: "#ff5800",
        yellow: "#ffd500",
        white: "#ffffff",
        black: "#000000"
    }

    var drawSticker = function(ctx, x, y, faceColor) {
        var delta = 3.5;
        ctx.fillRoundRect(x, y, 50, 50, 4, colors.black);
        ctx.fillRoundRect(x + delta, y + delta, 50 - 2 * delta, 50 - 2 * delta, 6, faceColor);
    }

    var drawFace = function() {
        var ctx = createCanvas(".canvas-container", 250);

        drawSticker(ctx, 50, 50, colors.blue);
        drawSticker(ctx, 100, 50, colors.red);
        drawSticker(ctx, 150, 50, colors.orange);

        drawSticker(ctx, 50, 100, colors.yellow);
        drawSticker(ctx, 100, 100, colors.blue);
        drawSticker(ctx, 150, 100, colors.white);

        drawSticker(ctx, 50, 150, colors.white);
        drawSticker(ctx, 100, 150, colors.red);
        drawSticker(ctx, 150, 150, colors.blue);
    }

    $(drawFace);
})();