using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Domain.Dtos.Form
{
    public class FormDto
    {
        public string Id { get; set; }
        public string formName { get; set; }
        public string formVersion { get; set; }
        public Control[] controls { get; set; }
        public Button[] buttons { get; set; }
    }


    public class Control
    {
        public string id { get; set; }
        public string type { get; set; }
        public string format { get; set; }
        public int index { get; set; }
        public string formId { get; set; }
        public bool readOnly { get; set; }
        public bool isRequired { get; set; }
        public string name { get; set; }
        public string label { get; set; }
        public string placeholder { get; set; }
        public List<object> value { get; set; }
        public string IsVisible { get; set; }
        public List<string> Roles { get; set; }
        public string icon { get; set; }
        public Style style { get; set; }
        public List<Validation> validations { get; set; }
        public List<int> dependencies { get; set; }
        public Conditionalview conditionalView { get; set; }
    }

    public class Style
    {
        public string border { get; set; }
        public string borderType { get; set; }
        public string borderColor { get; set; }
        public string backgroundColor { get; set; }
        public string textColor { get; set; }
        public string textAlign { get; set; }
        public string font { get; set; }
        public string fontSize { get; set; }
    }

    public class Conditionalview
    {
    }

    public class Validation
    {
        public string name { get; set; }
        public string value { get; set; }
        public string message { get; set; }
    }

    public class Button
    {
        public string id { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }
}

