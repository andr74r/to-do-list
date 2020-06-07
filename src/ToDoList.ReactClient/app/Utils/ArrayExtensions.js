Array.prototype.removeItemById = function(id) {
    if (!Array.isArray(this))
    {
        return this;
    }

    return this.filter(x => x.id != id);
}

Array.prototype.removeItemByName = function(name) {
    if (!Array.isArray(this))
    {
        return this;
    }

    return this.filter(x => x.name != name);
}

Array.prototype.replaceItemById = function(item) {
    if (!Array.isArray(this))
    {
        return this;
    }

    const newArray = this.filter(x => x.id != item.id);
    newArray.push(item);
    return newArray;
}

Array.prototype.sortById = function() {
    if (!Array.isArray(this))
    {
        return this;
    }
    return this.sort((x,y) => x.id - y.id);
}