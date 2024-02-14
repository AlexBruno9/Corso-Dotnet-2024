//servono a modificare la posizione di oggetti all'interno di un container
  
  
  The flex container properties are:

# flex-direction

    The flex-direction property defines in which direction the container wants to stack the flex items.

    {
        column;
        column-reverse;
        row;
        row-reverse;
    }

# flex-wrap

    The flex-wrap property specifies whether the flex items should wrap or not.
    //se vui che i container anziche stringersi vadano a capo

    {
        wrap;       
        nowrap;         // default
        wrap-reverse;
    }

# flex-flow

    The flex-flow property is a shorthand property for setting both the flex-direction and flex-wrap properties.

    {
        row wrap;       // molto simile a flex-wrap:wrap;

    }

# justify-content

    The justify-content property is used to align the flex items

    {
        center;
        flex-start;
        flex-end;
        space-around;
        space-between;
    }

# align-items

    The center value aligns the flex items in the middle of the container:

    {
        center;
        flex-start;
        flex-end;
        stretch;
        baseline;       // per allineare item di dimensioni diverse
    }

# align-content

    The align-content property is used to align the flex lines.

    {
        space-between;
        space-around;
        stretch;
        center;
        flex-start;
        flex-end;
    }

