interface ArtTemplate {
    (id, data);
    compile(source, options);
    render(source, options);
    helper(name, callback);
    config(name, value);
}

declare let template: ArtTemplate;