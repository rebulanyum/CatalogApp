(function (validator) {
    'use strict';
    validatorAdapters = validator.unobtrusive.adapters;

    validator.addMethod('greaterthan',
        function (value, element, params) {
            var min = params[1];
            return value >= min;
        });

    validatorAdapters.add('greaterthan', ['min'],
        function (input) {
            var element = $(options.form).find('select#Genre')[0];
            options.rules['classicmovie'] = [element, parseInt(options.params['year'])];
            options.messages['classicmovie'] = options.message;
        });
})($.validator);